namespace NivelAccesDate_CF_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trails", "Users_Id", "dbo.Users");
            DropIndex("dbo.Trails", new[] { "Users_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Trails");
            DropTable("dbo.TestClasses");
            DropTable("dbo.Regions");
            DropTable("dbo.Memberships");
            DropTable("dbo.Difficulties");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trails", "Users_Id", "dbo.Users");
            DropIndex("dbo.Trails", new[] { "Users_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Trails");
            DropTable("dbo.TestClasses");
            DropTable("dbo.Regions");
            DropTable("dbo.Memberships");
            DropTable("dbo.Difficulties");
        }
    }
}
