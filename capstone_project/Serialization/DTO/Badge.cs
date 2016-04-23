using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Serialization.DTO
{
    public class Badge : IBadge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public string IconName { get; set; }

        public string DisplayName { get; set; }

        public bool Active { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public ICharity Charity { get; set; }
    }
}
