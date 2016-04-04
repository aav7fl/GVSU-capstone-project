using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Data.Entities;

namespace GVSU.Data.Factories
{
    using GVSU.Data.Entities;
    using GVSU.Contracts;

    public static class VolunteerFactory
    {

        public static IVolunteer CreateVolunteer(Volunteer volunteer) {

            if (volunteer == null) return null;

            return new Serialization.DTO.Volunteer
            {
                Id = volunteer.Id,
                FirstName = volunteer.User.FirstName,
                LastName = volunteer.User.LastName,
                Description = volunteer.Description,
                Email = volunteer.User.Email,
                ZipCode = volunteer.ZipCode,
                IsActive = volunteer.IsActive
            };
        }

        public static Volunteer CreateVolunteer(IVolunteer volunteerDTO) {

            if (volunteerDTO == null) return null;

            return new Volunteer
            {
                Id = volunteerDTO.Id,
                Description = volunteerDTO.Description,
                ZipCode = volunteerDTO.ZipCode,
                IsActive = volunteerDTO.IsActive
            };
        }
    } 
}