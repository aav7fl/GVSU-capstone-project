using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Data.Factories
{
    using GVSU.Data.Entities;
    using GVSU.Contracts;

    public static class HourFactory
    {

        public static IHour CreateHour(Hour hour)
        {

            if (hour == null) return null;

            return new Serialization.DTO.Hour
            {
                Id = hour.Id,
                Volunteer = VolunteerFactory.CreateVolunteer(hour.Volunteer),
                Charity = CharityFactory.CreateCharity(hour.Charity),
                StartTime = hour.StartTime,
                EndTime = hour.EndTime,
                Verified = hour.Verified,
                CharityRating = hour.CharityRating,
                VolunteerRating = hour.VolunteerRating
            };
        }

        public static Hour CreateHour(IHour hourDTO)
        {

            if (hourDTO == null) return null;

            return new Hour
            {
                Id = hourDTO.Id,
                StartTime = hourDTO.StartTime,
                EndTime = hourDTO.EndTime,
                CharityRating = hourDTO.CharityRating,
                VolunteerRating = hourDTO.VolunteerRating
            };
        }
    }
}
