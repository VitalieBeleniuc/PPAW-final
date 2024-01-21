namespace NivelAccesDate_CF_ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quickfix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Regions", "IsActive");
            AddColumn("dbo.Regions", "IsActive", c => c.Boolean(nullable: true, defaultValue: true));
        }
        
        public override void Down()
        {
        }
    }
}
