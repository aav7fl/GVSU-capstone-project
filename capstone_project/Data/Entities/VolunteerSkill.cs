using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Data.Entities
{
    public class VolunteerSkill
    {
        public int Id { get; set; }

        public virtual Volunteer Volunteer { get; set;}

        public virtual Skill Skill { get; set; }

        [Range(0,5)]
        public int Level { get; set; }
    }
}
