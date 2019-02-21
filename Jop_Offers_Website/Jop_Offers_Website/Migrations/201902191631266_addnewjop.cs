namespace Jop_Offers_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewjop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jops", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jops", "UserId");
            AddForeignKey("dbo.Jops", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jops", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Jops", new[] { "UserId" });
            DropColumn("dbo.Jops", "UserId");
        }
    }
}
