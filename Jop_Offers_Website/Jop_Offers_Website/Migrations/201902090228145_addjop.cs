namespace Jop_Offers_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        jopTitle = c.String(nullable: false),
                        jopContent = c.String(nullable: false),
                        jopImg = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jops", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jops", new[] { "CategoryId" });
            DropTable("dbo.Jops");
        }
    }
}
