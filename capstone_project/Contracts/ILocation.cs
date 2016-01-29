﻿namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILocation
    {

        string Name { get; }
        
        string ShortDescription { get; }

        string AddressLine1 { get; }

        string AddressLine2 { get; }

        string City { get; }

        string State { get; }

        string ZipCode { get; }

        string Country { get; }

    }
}