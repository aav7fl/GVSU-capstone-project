using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ILocation
    {

        string Name { get; set; }

        string AddressLine1 { get; set; }

        string AddressLine2 { get; set; }

        string City { get; set; }

        string State { get; set; }

        string ZipCode { get; set; }

        string Country { get; set; }

        string ShortDescription { get; set; }

    }
}
