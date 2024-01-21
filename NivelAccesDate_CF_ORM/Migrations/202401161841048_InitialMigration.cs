namespace NivelAccesDate_CF_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipType = c.String(),
                        NumberOfMaps = c.Int(),
                        Duration = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        RegionName = c.String(),
                        RegionImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        TestName = c.Int(nullable: false),
                        NewProperty1 = c.Int(nullable: false),
                        NewProperty2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LenghtInKm = c.Int(nullable: false),
                        WalkImageUrl = c.String(),
                        MapLink = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        Users_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        ProfileImageUrl = c.String(),
                        MembershipId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
