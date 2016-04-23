using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Data.Entities
{
    public class VolunteerBadges
    {
        public int Id { get; set; }

        public int VolunteerId { get; set; }

        [ForeignKey("VolunteerId")]
        public virtual Volunteer Volunteer { get; set; }

        public int BadgeId { get; set; }

        [ForeignKey("BadgeId")]
        public virtual Badge Badge { get; set; }

        public bool Complete { get; set; }

        public double Progress { get; set; }
    }
}
