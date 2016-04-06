namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVolunteerService : IDisposable
    {
        IVolunteer GetVolunteerById(int id);

        IEnumerable<IVolunteer> GetAllVolunteers();

        int CreateVolunteer(IVolunteer volunteer);

        void UpdateVolunteer(IVolunteer volunteer);

        void DeleteVolunteerById(int id);

        IEnumerable<IHour> GetHoursByVolunteer(int id);

        int CreateHour(IHour hourDTO);

        void UpdateHour(IHour hourDTO);

        void DeleteHourById(int id);
    }
}
