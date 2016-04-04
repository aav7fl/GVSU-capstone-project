namespace GVSU.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;
    using Serialization.DTO;

    public class VolunteerServiceSimulator : IVolunteerService
    {
        private readonly IDictionary<int, IVolunteer> _volunteerList;

        public VolunteerServiceSimulator()
        {
            _volunteerList = new Dictionary<int, IVolunteer>();
        }

        public int CreateVolunteer(IVolunteer volunteer)
        {
            _volunteerList.Add(volunteer.Id, volunteer);
            return volunteer.Id;
        }

        public void DeleteVolunteerById(int id)
        {
            _volunteerList.Remove(id);
        }

        public IEnumerable<IVolunteer> GetAllVolunteers()
        {
            return _volunteerList.Values;
        }

        public IVolunteer GetVolunteerById(int id)
        {
            return _volunteerList[id];
        }

        public void UpdateVolunteer(IVolunteer volunteer)
        {
            _volunteerList[volunteer.Id] = volunteer;
        }

        public void Dispose()
        {
        }

        public IEnumerable<IHour> GetHoursByVolunteer(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateHour(IHour hourDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateHour(IHour hourDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteHourById(int id)
        {
            throw new NotImplementedException();
        }
    }
}