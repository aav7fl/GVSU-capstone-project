using System;
using System.Collections.Generic;
using System.Linq;
namespace GVSU.Serialization.DTO
{
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class Hour : IHour
    {
        public int Id { get; }

        public IVolunteer Volunteer { get; }

        public ICharity Charity { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public bool Verified { get; }
    }
}
