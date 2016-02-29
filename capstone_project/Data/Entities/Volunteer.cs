namespace GVSU.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Volunteer
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
