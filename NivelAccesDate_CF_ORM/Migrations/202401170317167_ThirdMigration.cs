namespace NivelAccesDate_CF_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Trails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    LenghtInKm = c.Int(nullable: false),
                    WalkImageUrl = c.String(),
                    RegionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.RegionId);
        }
        
        public override void Down()
        {
            
        }
    }
}
