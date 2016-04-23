namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        ImageUrl = c.String(),
                        IconName = c.String(),
                        DisplayName = c.String(),
                        Active = c.Boolean(nullable: false),
                        MinValue = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        Charity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charities", t => t.Charity_Id)
                .Index(t => t.Charity_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VolunteerBadges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VolunteerId = c.Int(nullable: false),
                        BadgeId = c.Int(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        Progress = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Badges", t => t.BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.BadgeId);
            
            CreateTable(
                "dbo.VolunteerSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        Volunteer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.Volunteer_Id);
            
            AddColumn("dbo.Hours", "CharityRating", c => c.Int());
            AddColumn("dbo.Hours", "VolunteerRating", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolunteerSkills", "Volunteer_Id", "dbo.Volunteers");
            DropForeignKey("dbo.VolunteerSkills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.VolunteerBadges", "VolunteerId", "dbo.Volunteers");
            DropForeignKey("dbo.VolunteerBadges", "BadgeId", "dbo.Badges");
            DropForeignKey("dbo.Badges", "Charity_Id", "dbo.Charities");
            DropIndex("dbo.VolunteerSkills", new[] { "Volunteer_Id" });
            DropIndex("dbo.VolunteerSkills", new[] { "Skill_Id" });
            DropIndex("dbo.VolunteerBadges", new[] { "BadgeId" });
            DropIndex("dbo.VolunteerBadges", new[] { "VolunteerId" });
            DropIndex("dbo.Badges", new[] { "Charity_Id" });
            DropColumn("dbo.Hours", "VolunteerRating");
            DropColumn("dbo.Hours", "CharityRating");
            DropTable("dbo.VolunteerSkills");
            DropTable("dbo.VolunteerBadges");
            DropTable("dbo.Skills");
            DropTable("dbo.Badges");
        }
    }
}
