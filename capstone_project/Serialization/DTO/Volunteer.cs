namespace GVSU.Serialization.DTO
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public class Volunteer : IVolunteer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public int? ZipCode { get; set; }

        public bool IsActive { get; set; }
    }
}
