namespace GVSU.Simulators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;

    public class VolunteerRepositorySimulator : IRepository<Volunteer>
    {
        private List<Volunteer> volunteerList;

        public VolunteerRepositorySimulator()
        {
            this.volunteerList = new List<Volunteer>();
        }

        IEnumerable<Volunteer> IRepository<Volunteer>.List
        {
            get { return this.volunteerList; }
        }

        void IRepository<Volunteer>.Add(Volunteer entity)
        {
            this.volunteerList.Add(entity);
        }

        void IRepository<Volunteer>.Delete(Volunteer entity)
        {
            this.volunteerList.Remove(entity);
        }

        Volunteer IRepository<Volunteer>.FindById(long id)
        {
            return this.volunteerList.Find(e => e.Id == id);
        }

        void IRepository<Volunteer>.Update(Volunteer entity)
        {
            this.volunteerList.Remove(this.volunteerList.Find(e => e.Id == entity.Id));
            this.volunteerList.Add(entity);
        }
    }
}