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

    public class VolunteerFactory
    {
        public VolunteerFactory() {
        }

        public IVolunteer CreateVolunteer(Volunteer volunteer) {
            return new Serialization.DTO.Volunteer
            {
                Id = volunteer.Id,
                FirstName = volunteer.User.FirstName,
                LastName = volunteer.User.LastName,
                Description = volunteer.Description,
                IsActive = volunteer.IsActive
            };
        }

        public Volunteer CreateVolunteer(IVolunteer volunteerDTO) {
            return new Volunteer
            {
                Id = volunteerDTO.Id,
                User = new ApplicationUser {
                    FirstName = volunteerDTO.FirstName,
                    LastName = volunteerDTO.LastName
                },
                Description = volunteerDTO.Description,
                IsActive = volunteerDTO.IsActive
            };
        }
    } 
}