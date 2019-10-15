namespace MVCHCL.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailablestocktoMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Availablestock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Availablestock");
        }
    }
}
