namespace GVSU.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Hour
    {
        public Hour() {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Verified = false;
        }
        public int Id { get; set; }

        public Volunteer Volunteer { get; set; }

        public Charity Charity { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Verified { get; set; }
    }
}