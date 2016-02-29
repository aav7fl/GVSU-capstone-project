using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Data.Entities
{
    public class Charity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string WebsiteURL { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ILocation Locations { get; set; }

        public bool Claimed { get; set; }

        public bool Verified { get; set; }
    }
}
