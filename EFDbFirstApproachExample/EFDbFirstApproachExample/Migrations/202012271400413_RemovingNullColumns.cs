namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingNullColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Active", c => c.Boolean());
        }
    }
}
