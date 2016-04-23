using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Serialization.DTO
{
    public class Category : ICategory
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
