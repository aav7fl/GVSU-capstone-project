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

    public class SQLVolunteerService : VolunteerServiceDecorator
    {
        private readonly ApplicationDbContext _store;
        private readonly VolunteerFactory _volunteerFactory = new VolunteerFactory();

        public SQLVolunteerService(IVolunteerService service)
            : base(service)
        {
            _store = new ApplicationDbContext(); // TO-DO: inject dbcontext, rather than instantiate new one
        }

        public override IEnumerable<IVolunteer> GetAllVolunteers()
        {
            return _store.Volunteers.Select(e => _volunteerFactory.CreateVolunteer(e));
        }

        public override IVolunteer GetVolunteerById(int id)
        {
            return _volunteerFactory.CreateVolunteer(_store.Volunteers.Find(id));
        }

        public override int CreateVolunteer(IVolunteer volunteerDTO)
        {
            Volunteer v = _store.Volunteers.Add(_volunteerFactory.CreateVolunteer(volunteerDTO));
            _store.SaveChanges();
            return v.Id;
        }

        public override void UpdateVolunteer(IVolunteer volunteerDTO)
        {
            Volunteer oldV = _store.Volunteers.Include(x => x.User)
                .Single(x => x.Id == volunteerDTO.Id);

            Volunteer newV = _volunteerFactory.CreateVolunteer(volunteerDTO);

            _store.Entry(oldV).CurrentValues.SetValues(newV);
            _store.SaveChanges();
        }

        public override void DeleteVolunteerById(int id)
        {
            Volunteer v = _store.Volunteers.Find(id);
            _store.Volunteers.Remove(v);
            _store.SaveChanges();
        }
    }
}
