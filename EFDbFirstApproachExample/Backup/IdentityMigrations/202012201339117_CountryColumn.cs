namespace EFDbFirstApproachExample.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "country");
        }
    }
}
