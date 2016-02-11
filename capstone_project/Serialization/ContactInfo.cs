using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;

namespace GVSU.Serialization
{
    public class ContactInfo : IContactInfo
    {
        public string Email { get; set; }

        public string Fax { get; set; }

        public string PhoneNumber { get; set; }
    }
}
