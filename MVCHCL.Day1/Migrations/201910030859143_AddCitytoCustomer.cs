namespace MVCHCL.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCitytoCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "City");
        }
    }
}
