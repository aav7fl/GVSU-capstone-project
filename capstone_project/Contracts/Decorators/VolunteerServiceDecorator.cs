using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts.Decorators
{
    public class VolunteerServiceDecorator : IVolunteerService
    {
        private readonly IVolunteerService _service;

        protected VolunteerServiceDecorator(IVolunteerService service)
        {
            _service = service;
        }

        public virtual int CreateVolunteer(IVolunteer volunteer)
        {
            return _service.CreateVolunteer(volunteer);
        }

        public virtual void DeleteVolunteerById(int id)
        {
            _service.DeleteVolunteerById(id);
        }

        public virtual IEnumerable<IVolunteer> GetAllVolunteers()
        {
            return _service.GetAllVolunteers();
        }

        public virtual IVolunteer GetVolunteerById(int id)
        {
            return _service.GetVolunteerById(id);
        }

        public virtual void UpdateVolunteer(IVolunteer volunteer)
        {
            _service.UpdateVolunteer(volunteer);
        }
    }
}
