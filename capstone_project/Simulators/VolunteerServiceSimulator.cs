namespace GVSU.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;

    public class VolunteerServiceSimulator : IVolunteerService
    {
        private readonly IDictionary<int, IVolunteer> volunteerList;

        public VolunteerServiceSimulator()
        {
            volunteerList = new Dictionary<int, IVolunteer>();
        }

        public string CreateVolunteer(IVolunteer volunteer)
        {
            volunteerList.Add(volunteer.Id, volunteer);
            return "1";
        }

        public string DeleteVolunteerById(int id)
        {
            volunteerList.Remove(id);
            return "";
        }

        public IEnumerable<IVolunteer> GetAllVolunteers()
        {
            return volunteerList.Values;
        }

        public IVolunteer GetVolunteerById(int id)
        {
            return volunteerList[id];
        }

        public string UpdateVolunteer(IVolunteer volunteer)
        {
            volunteerList[volunteer.Id] = volunteer;
            return "";
        }
    }
}