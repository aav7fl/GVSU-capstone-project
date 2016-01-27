using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface IContactInfo
    {
        string PhoneNumber { get; set; }

        string Email { get; set; }
    }
}
