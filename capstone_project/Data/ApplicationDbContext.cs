using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;
using GVSU.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;


namespace GVSU.Data {

   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Default constructor used for running EF migrations
        /// </summary>
        public ApplicationDbContext()
            //:base("DefaultConnection", throwIfV1Schema: false) {
            //:base("LocalConnection", throwIfV1Schema: false) {
            :base("AzureSQLServerConnection", throwIfV1Schema: false) {
        }

        /// <summary>
        /// Constructor used by Web Project with dynamic connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public ApplicationDbContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true; 
        }

        public static ApplicationDbContext Create(string connectionString)
        {
            return new ApplicationDbContext(connectionString);
        }

        public System.Data.Entity.DbSet<Volunteer> Volunteers { get; set; }
        public System.Data.Entity.DbSet<Charity> Charities { get; set; }
        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public System.Data.Entity.DbSet<Location> Locations { get; set; }
        public System.Data.Entity.DbSet<Hour> Hours { get; set; }
        public System.Data.Entity.DbSet<Skill> Skills { get; set; }
        public System.Data.Entity.DbSet<VolunteerSkill> VolunteerSkills { get; set; }
        public System.Data.Entity.DbSet<Badge> Badges { get; set; }
        public System.Data.Entity.DbSet<VolunteerBadges> VolunteerBadges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Volunteer Model Builder
            modelBuilder.Entity<Volunteer>()
                .HasRequired<ApplicationUser>(v => v.User)
                .WithRequiredDependent(u => u.Volunteer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Volunteer>()
                .HasMany<Charity>(v => v.Charities)
                .WithMany(c => c.Volunteers)
                .Map(x =>
                {
                    x.MapLeftKey("VolunteerId");
                    x.MapRightKey("CharityId");
                    x.ToTable("VolunteerCharities");
                });

            // Charity Model Builder
            modelBuilder.Entity<Location>()
                .HasRequired<Charity>(l => l.Charity)
                .WithMany(c => c.Locations)
                .WillCascadeOnDelete(true);

            // Hour Model Builder
            modelBuilder.Entity<Hour>()
                .HasRequired<Volunteer>(h => h.Volunteer);

            modelBuilder.Entity<Hour>()
                .HasRequired<Charity>(h => h.Charity);
        }
    }
}
