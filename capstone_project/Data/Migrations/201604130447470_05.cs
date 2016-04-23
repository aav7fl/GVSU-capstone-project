namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Badges", name: "Charity_Id", newName: "CharityId");
            RenameIndex(table: "dbo.Badges", name: "IX_Charity_Id", newName: "IX_CharityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Badges", name: "IX_CharityId", newName: "IX_Charity_Id");
            RenameColumn(table: "dbo.Badges", name: "CharityId", newName: "Charity_Id");
        }
    }
}
