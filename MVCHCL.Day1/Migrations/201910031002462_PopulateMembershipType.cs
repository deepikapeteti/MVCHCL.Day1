namespace MVCHCL.Day1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT MembershipTypes(Type,Duration,Signupfee,Discount)values('yearly',12,1200,20)");
            Sql("INSERT MembershipTypes(Type,Duration,Signupfee,Discount)values('Halfyearly',6,600,15)");
            Sql("INSERT MembershipTypes(Type,Duration,Signupfee,Discount)values('Quaterly',3,300,10)");
            Sql("INSERT MembershipTypes(Type,Duration,Signupfee,Discount)values('PayAsYouGo',0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
