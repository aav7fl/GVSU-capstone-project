namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Hour
    {
        public long Id { get; set; }

        public long VolunteerId { get; set; }

        public long CharityId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Verified { get; set; }
    }
}
