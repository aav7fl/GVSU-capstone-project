using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GVSU.Serialization.DTO
{
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class User : IUser
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFirstLogin { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
