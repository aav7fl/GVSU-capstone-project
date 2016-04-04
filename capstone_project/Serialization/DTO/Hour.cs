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
        public int Id { get; set; }

        public IVolunteer Volunteer { get; set; }

        public ICharity Charity { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Verified { get; set; }
    }
}
