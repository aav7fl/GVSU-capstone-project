using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Data.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public int? CharityId { get; set; }

        [ForeignKey("CharityId")]
        public virtual Charity Charity { get; set; }
    }
}
