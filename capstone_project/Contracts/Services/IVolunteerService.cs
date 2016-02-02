namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVolunteerService
    {
        IVolunteer GetVolunteerById(int id);

        IEnumerable<IVolunteer> GetAllVolunteers();

        string CreateVolunteer(IVolunteer volunteer);

        string UpdateVolunteer(IVolunteer volunteer);

        string DeleteVolunteerById(int id);
    }
}
