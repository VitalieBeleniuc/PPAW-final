namespace NivelAccesDate_CF_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "IsActive", c => c.Boolean(nullable: true, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "IsActive");
        }
    }
}
