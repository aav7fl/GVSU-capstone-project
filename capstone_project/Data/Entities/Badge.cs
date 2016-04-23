using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GVSU.Data.Entities
{
    public class Badge
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
        public int? CharityId { get; set; }
        [ForeignKey("CharityId")]
        public virtual Charity Charity { get; set; }
    }
}
