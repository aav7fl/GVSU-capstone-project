namespace GVSU.Serialization.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class Charity : ICharity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string WebsiteURL { get; set; }

        public DateTime? CreatedAt { get; set; }

        public IUser CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public IUser UpdatedBy { get; set; }

        public ICollection<ILocation> Locations { get; set; }

        public bool Claimed { get; set; }

        public bool Verified { get; set; }
    }
}
