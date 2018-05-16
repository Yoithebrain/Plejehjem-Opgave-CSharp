namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateTimeFormatInScheudle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "DateForVisiting", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "DateForVisiting", c => c.DateTime(nullable: false));
        }
    }
}
