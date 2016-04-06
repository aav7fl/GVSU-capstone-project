namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHour
    {
        int Id { get; }

        IVolunteer Volunteer { get; }

        ICharity Charity { get; }

        DateTime? StartTime { get; }

        DateTime? EndTime { get; }

        bool Verified { get; }
    }
}
