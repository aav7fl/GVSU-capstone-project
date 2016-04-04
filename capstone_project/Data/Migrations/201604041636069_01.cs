namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hours", "Charity_Id", "dbo.Charities");
            DropForeignKey("dbo.Hours", "Volunteer_Id", "dbo.Volunteers");
            DropIndex("dbo.Hours", new[] { "Charity_Id" });
            DropIndex("dbo.Hours", new[] { "Volunteer_Id" });
            RenameColumn(table: "dbo.Charities", name: "CreatedBy_Id", newName: "CreatedById");
            RenameColumn(table: "dbo.Hours", name: "Charity_Id", newName: "CharityId");
            RenameColumn(table: "dbo.Hours", name: "Volunteer_Id", newName: "VolunteerId");
            RenameIndex(table: "dbo.Charities", name: "IX_CreatedBy_Id", newName: "IX_CreatedById");
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        CharityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charities", t => t.CharityId, cascadeDelete: true)
                .Index(t => t.CharityId);
            
            CreateTable(
                "dbo.VolunteerCharities",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false),
                        CharityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VolunteerId, t.CharityId })
                .ForeignKey("dbo.Volunteers", t => t.VolunteerId, cascadeDelete: true)
                .ForeignKey("dbo.Charities", t => t.CharityId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.CharityId);
            
            AddColumn("dbo.Charities", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Charities", "UpdatedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Hours", "CharityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hours", "VolunteerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Charities", "UpdatedById");
            CreateIndex("dbo.Hours", "VolunteerId");
            CreateIndex("dbo.Hours", "CharityId");
            AddForeignKey("dbo.Charities", "UpdatedById", "dbo.Users", "UserId");
            AddForeignKey("dbo.Hours", "CharityId", "dbo.Charities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Hours", "VolunteerId", "dbo.Volunteers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hours", "VolunteerId", "dbo.Volunteers");
            DropForeignKey("dbo.Hours", "CharityId", "dbo.Charities");
            DropForeignKey("dbo.Charities", "UpdatedById", "dbo.Users");
            DropForeignKey("dbo.Locations", "CharityId", "dbo.Charities");
            DropForeignKey("dbo.VolunteerCharities", "CharityId", "dbo.Charities");
            DropForeignKey("dbo.VolunteerCharities", "VolunteerId", "dbo.Volunteers");
            DropIndex("dbo.VolunteerCharities", new[] { "CharityId" });
            DropIndex("dbo.VolunteerCharities", new[] { "VolunteerId" });
            DropIndex("dbo.Hours", new[] { "CharityId" });
            DropIndex("dbo.Hours", new[] { "VolunteerId" });
            DropIndex("dbo.Locations", new[] { "CharityId" });
            DropIndex("dbo.Charities", new[] { "UpdatedById" });
            AlterColumn("dbo.Hours", "VolunteerId", c => c.Int());
            AlterColumn("dbo.Hours", "CharityId", c => c.Int());
            DropColumn("dbo.Charities", "UpdatedById");
            DropColumn("dbo.Charities", "UpdatedAt");
            DropTable("dbo.VolunteerCharities");
            DropTable("dbo.Locations");
            RenameIndex(table: "dbo.Charities", name: "IX_CreatedById", newName: "IX_CreatedBy_Id");
            RenameColumn(table: "dbo.Hours", name: "VolunteerId", newName: "Volunteer_Id");
            RenameColumn(table: "dbo.Hours", name: "CharityId", newName: "Charity_Id");
            RenameColumn(table: "dbo.Charities", name: "CreatedById", newName: "CreatedBy_Id");
            CreateIndex("dbo.Hours", "Volunteer_Id");
            CreateIndex("dbo.Hours", "Charity_Id");
            AddForeignKey("dbo.Hours", "Volunteer_Id", "dbo.Volunteers", "Id");
            AddForeignKey("dbo.Hours", "Charity_Id", "dbo.Charities", "Id");
        }
    }
}
