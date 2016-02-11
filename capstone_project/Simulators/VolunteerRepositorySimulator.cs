namespace GVSU.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;

    public class VolunteerRepositorySimulator : IRepository<IVolunteer>
    {
        private List<IVolunteer> volunteerList;

        public VolunteerRepositorySimulator()
        {
            this.volunteerList = new List<IVolunteer>();
        }

        IEnumerable<IVolunteer> IRepository<IVolunteer>.List
        {
            get { return this.volunteerList; }
        }

        void IRepository<IVolunteer>.Add(IVolunteer volunteer)
        {
            this.volunteerList.Add(volunteer);
        }

        void IRepository<IVolunteer>.Delete(IVolunteer volunteer)
        {
            this.volunteerList.Remove(volunteer);
        }

        IVolunteer IRepository<IVolunteer>.FindById(long id)
        {
            return this.volunteerList.Find(e => e.Id == id);
        }

        void IRepository<IVolunteer>.Update(IVolunteer volunteer)
        {
            this.volunteerList.Remove(this.volunteerList.Find(e => e.Id == volunteer.Id));
            this.volunteerList.Add(volunteer);
        }
    }
}