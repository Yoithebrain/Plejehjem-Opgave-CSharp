namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "CitizensList_DataGroupField", c => c.String());
            AddColumn("dbo.Schedules", "CitizensList_DataTextField", c => c.String());
            AddColumn("dbo.Schedules", "CitizensList_DataValueField", c => c.String());
            AddColumn("dbo.Schedules", "EmployeeList_DataGroupField", c => c.String());
            AddColumn("dbo.Schedules", "EmployeeList_DataTextField", c => c.String());
            AddColumn("dbo.Schedules", "EmployeeList_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "EmployeeList_DataValueField");
            DropColumn("dbo.Schedules", "EmployeeList_DataTextField");
            DropColumn("dbo.Schedules", "EmployeeList_DataGroupField");
            DropColumn("dbo.Schedules", "CitizensList_DataValueField");
            DropColumn("dbo.Schedules", "CitizensList_DataTextField");
            DropColumn("dbo.Schedules", "CitizensList_DataGroupField");
        }
    }
}
