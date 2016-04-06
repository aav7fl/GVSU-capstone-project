namespace GVSU.Serialization.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class Location : ILocation
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string AddressLine1 { get; }

        public string AddressLine2 { get; }

        public string City { get; }

        public string State { get; }

        public string ZipCode { get; }

        public string Country { get; }
    }
}
