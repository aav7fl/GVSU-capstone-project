using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Serialization
{
    public class User : IUser
    {
        public IContactInfo ContactInfo { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }
    }
}
