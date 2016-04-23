namespace GVSU.Data.Services
{
    using System.Web;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.Contracts;
    using GVSU.Contracts.Decorators;
    using GVSU.Data.Entities;
    using GVSU.Data.Factories;
    using System;

    public class SQLVolunteerService : IVolunteerService, IDisposable
    {
        private readonly ApplicationDbContext _store;

        public SQLVolunteerService(ApplicationDbContext dbContext)
        {
            _store = dbContext;
        }

        public IEnumerable<IVolunteer> GetAllVolunteers()
        {
            IEnumerable<Volunteer> v = _store.Volunteers
                .Include(e => e.User)
                .ToList();

            return v.Select(e => VolunteerFactory.CreateVolunteer(e));
        }

        public IVolunteer GetVolunteerById(int id)
        {
            try
            {
                Volunteer volunteer = _store.Volunteers
                    .Include(e => e.User)
                    .Single(v => v.Id == id);
                return VolunteerFactory.CreateVolunteer(volunteer);
            }
            catch (InvalidOperationException) {
                return null;
            }
            
        }

        public int CreateVolunteer(IVolunteer volunteerDTO)
        {
            Volunteer v = VolunteerFactory.CreateVolunteer(volunteerDTO);
            v = _store.Volunteers.Add(v);
            _store.SaveChanges();
            return v.Id;
        }

        public void UpdateVolunteer(IVolunteer volunteerDTO)
        {
            Volunteer oldV = _store.Volunteers
                .Include(x => x.User)
                .Single(x => x.Id == volunteerDTO.Id);

            _store.Entry(oldV).CurrentValues.SetValues(volunteerDTO);
            _store.Entry(oldV.User).CurrentValues.SetValues(
                new {
                    FirstName = volunteerDTO.FirstName,
                    LastName = volunteerDTO.LastName,
                    Email = volunteerDTO.Email
                }
            );
            _store.SaveChanges();
        }

        public void DeleteVolunteerById(int id)
        {
            Volunteer v = _store.Volunteers
                .Include(e => e.User)
                .Include(e => e.Charities)
                .Single(x => x.Id == id);

            _store.Users.Remove(v.User); //Cascades on delete
            _store.SaveChanges();
        }

        public void ToggleCharity(int volunteerId, int charityId) {

           Volunteer v = _store.Volunteers
                .Include(e => e.Charities)
                .Single(x => x.Id == volunteerId);

            Charity c = _store.Charities
                .Find(charityId);

            if (v.Charities.Any(x => x.Id == charityId))
                v.Charities.Remove(c);
            else
                v.Charities.Add(c);

            _store.SaveChanges();
        }

        public IEnumerable<IHour> GetHoursByVolunteer(int id) {

            IEnumerable<Hour> hours = _store.Hours
                .Include(e => e.Charity)
                .Include(e => e.Volunteer)
                .Where(e => e.VolunteerId == id)
                .ToList();

            return hours.Select(e => HourFactory.CreateHour(e));
        }

        public int CreateHour(IHour hourDTO) {

            Hour h = HourFactory.CreateHour(hourDTO);

            Charity c = _store.Charities.SingleOrDefault(e => e.Id == hourDTO.Charity.Id);

            if (c == null && hourDTO.Charity != null)
                _store.Charities.Add(CharityFactory.CreateCharity(hourDTO.Charity));

            h.VolunteerId = hourDTO.Volunteer.Id;
            h.CharityId = hourDTO.Charity.Id;

            _store.Hours.Add(h);
            _store.SaveChanges();

            return h.Id;
        }

        public void UpdateHour(IHour hourDTO)
        {

            Hour oldH = _store.Hours.Single(e => e.Id == hourDTO.Id);
            
            _store.Entry(oldH).CurrentValues.SetValues(hourDTO);

            oldH.VolunteerId = hourDTO.Volunteer.Id;
            oldH.CharityId = hourDTO.Charity.Id;

            _store.SaveChanges();

        }

        public void DeleteHourById(int id) {
            Hour hour = _store.Hours.Find(id);
            _store.Hours.Remove(hour);
            _store.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
