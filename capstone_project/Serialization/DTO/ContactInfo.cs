namespace GVSU.Serialization.DTO
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class ContactInfo : IContactInfo
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
