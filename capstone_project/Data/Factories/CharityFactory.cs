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

    public static class CharityFactory
    {
        public static ICharity CreateCharity(Charity charity)
        {

            if (charity == null) return null;

            return new Serialization.DTO.Charity
            {
                Id = charity.Id,
                Name = charity.Name,
                ShortDescription = charity.ShortDescription,
                Email = charity.Email,
                PhoneNumber = charity.PhoneNumber,
                WebsiteURL = charity.WebsiteURL,
                CreatedAt = charity.CreatedAt,
                CreatedBy = charity.CreatedBy != null ? new Serialization.DTO.User {
                    Id = charity.CreatedBy.Id,
                    FirstName = charity.CreatedBy.FirstName,
                    LastName = charity.CreatedBy.LastName
                } : null,
                UpdatedAt = charity.UpdatedAt,
                UpdatedBy = charity.UpdatedBy != null ? new Serialization.DTO.User {
                    Id = charity.UpdatedBy.Id,
                    FirstName = charity.UpdatedBy.FirstName,
                    LastName = charity.UpdatedBy.LastName
                } : null,
                Locations = null,
                Claimed = charity.Claimed,
                Verified = charity.Verified
            };
        }

        public static Charity CreateCharity(ICharity charityDTO)
        {

            if (charityDTO == null) return null;

            return new Charity
            {
                Id = charityDTO.Id,
                Name = charityDTO.Name,
                ShortDescription = charityDTO.ShortDescription,
                Email = charityDTO.Email,
                PhoneNumber = charityDTO.PhoneNumber,
                WebsiteURL = charityDTO.WebsiteURL,
                CreatedAt = charityDTO.CreatedAt,
                UpdatedAt = charityDTO.UpdatedAt,
                Locations = null
            };
        }
    }
}