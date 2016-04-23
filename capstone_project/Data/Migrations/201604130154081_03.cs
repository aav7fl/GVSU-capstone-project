namespace GVSU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Charities", "CategoryId", c => c.Int());
            CreateIndex("dbo.Charities", "CategoryId");
            AddForeignKey("dbo.Charities", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charities", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Charities", new[] { "CategoryId" });
            DropColumn("dbo.Charities", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
