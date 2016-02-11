namespace GVSU.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class VolunteerService : IVolunteerService
    {
        //business logic classes don't know anything about who is calling them
        //general busines rules
        //validation
        //IVolunteerStore
        //ICharityStore

        public VolunteerService()
        {

        }
        string IVolunteerService.CreateVolunteer(IVolunteer volunteer)
        {
            throw new NotImplementedException();
        }

        string IVolunteerService.DeleteVolunteerById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IVolunteer> IVolunteerService.GetAllVolunteers()
        {
            throw new NotImplementedException();
        }

        IVolunteer IVolunteerService.GetVolunteerById(int id)
        {
            throw new NotImplementedException();
        }

        string IVolunteerService.UpdateVolunteer(IVolunteer volunteer)
        {
            throw new NotImplementedException();
        }
    }
}
