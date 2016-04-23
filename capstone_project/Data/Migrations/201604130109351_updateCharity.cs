namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCharity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hours", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hours", "Rating");
        }
    }
}
