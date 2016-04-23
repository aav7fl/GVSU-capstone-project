namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GVSU.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GVSU.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                c => c.Description,
                 new Entities.Category { Description = "Organization"},
                 new Entities.Category { Description = "Education" },
                 new Entities.Category { Description = "Arts & Culture" },
                 new Entities.Category { Description = "Human Services & Health" },
                 new Entities.Category { Description = "Animal Welfare" },
                 new Entities.Category { Description = "Environment" },
                 new Entities.Category { Description = "International NGOs" },
                 new Entities.Category { Description = "Other"}
            );

            context.Badges.AddOrUpdate(
                c => new {
                    c.Name,
                    c.ShortDescription,
                    c.DisplayName,
                    c.MinValue,
                    c.MaxValue,
                    c.Active
                },
                new Entities.Badge
                {
                    Name = "Initiate",
                    ShortDescription = "Welcome! The force is strong in you.",
                    DisplayName = "1+",
                    MinValue = 0,
                    MaxValue = 1,
                    Active = true
                },
                new Entities.Badge
                {
                    Name = "Padawan",
                    ShortDescription = "Keep it up! The good side is winning.",
                    DisplayName = "10+",
                    MinValue = 0,
                    MaxValue = 10,
                    Active = true
                },
                new Entities.Badge { 
                    Name = "Knight",
                    ShortDescription = "Do. Or do not. There is no try.",
                    DisplayName = "25+",
                    MinValue = 0,
                    MaxValue = 25,
                    Active = true   
                },
                new Entities.Badge {
                    Name = "Master",
                    ShortDescription = "Awe-inspiring.",
                    DisplayName = "50+",
                    MinValue = 0,
                    MaxValue = 50,
                    Active = true
                }
            );
        }
    }
}
