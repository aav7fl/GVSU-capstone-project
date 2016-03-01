using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GVSU.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GVSU.Data
{
    public partial class ApplicationUser : IdentityUser
    {
        // Inherited Properties: UserId, UserName, Email, EmailConfirmed ...

        public ApplicationUser() {
            IsFirstLogin = true;
            CreatedAt = DateTime.Now;        
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFirstLogin { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Volunteer Volunteer { get; set; }

        // TO-DO: Put function in static utility class, and pass in ApplicationUser as parameter
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // TO-DO: Add application user fields as claim type
            // userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, your_profile == null ? string.Empty : your_profile.FirstName));
            // userIdentity.AddClaim(new Claim(ClaimTypes.Surname, your_profile == null ? string.Empty : your_profile.LastName));

            return userIdentity;
        }
    }
}
