namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletelists : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "CitizensList_DataGroupField");
            DropColumn("dbo.Schedules", "CitizensList_DataTextField");
            DropColumn("dbo.Schedules", "CitizensList_DataValueField");
            DropColumn("dbo.Schedules", "EmployeeList_DataGroupField");
            DropColumn("dbo.Schedules", "EmployeeList_DataTextField");
            DropColumn("dbo.Schedules", "EmployeeList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "EmployeeList_DataValueField", c => c.String());
            AddColumn("dbo.Schedules", "EmployeeList_DataTextField", c => c.String());
            AddColumn("dbo.Schedules", "EmployeeList_DataGroupField", c => c.String());
            AddColumn("dbo.Schedules", "CitizensList_DataValueField", c => c.String());
            AddColumn("dbo.Schedules", "CitizensList_DataTextField", c => c.String());
            AddColumn("dbo.Schedules", "CitizensList_DataGroupField", c => c.String());
        }
    }
}
