namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Charities", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Charities", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Charities", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Charities", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
