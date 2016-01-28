namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IHour
    {
        public long Id { get; }

        public IVolunteer Volunteer { get; }

        public ICharity Charity { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public bool Verified { get; }
    }
}
