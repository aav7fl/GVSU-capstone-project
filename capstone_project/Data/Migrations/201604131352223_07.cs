namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charities", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Charities", "ImageUrl");
        }
    }
}
