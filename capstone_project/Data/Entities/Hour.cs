namespace GVSU.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Hour
    {
        public Hour() {
        }
        public int Id { get; set; }

        public int? VolunteerId { get; set; }

        [ForeignKey("VolunteerId")]
        public Volunteer Volunteer { get; set; }

        public int? CharityId { get; set; }

        [ForeignKey("CharityId")]
        public Charity Charity { get; set; }

        [Required]
        public DateTime? StartTime { get; set; }

        [Required]
        public DateTime? EndTime { get; set; }

        public bool Verified { get; set; }

        [Range(0,5)]
        public int? CharityRating { get; set; }

        [Range(0,5)]
        public int? VolunteerRating { get; set; }
    }
}