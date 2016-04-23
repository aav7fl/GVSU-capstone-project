using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Data.Entities
{
    public class Charity
    {
        public Charity() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set;}

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string WebsiteURL { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual ApplicationUser UpdatedBy { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public bool Claimed { get; set; }

        public bool Verified { get; set; }

        public virtual ICollection<Volunteer> Volunteers { get; set; }

        [NotMapped]
        public double TotalHours { get; set; }

        [NotMapped]
        public int FollowersCount { get; set; }

        [NotMapped]
        public double? AverageRating { get; set; }
    }
}
