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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFirstLogin { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Volunteer Volunteer { get; set; }

        // TO-DO: Put in static utility class, and pass in ApplicationUser as parameter
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
