namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dropdowns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitizensDropDowns",
                c => new
                    {
                        citizensID = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.citizensID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID)
                .Index(t => t.Schedule_ScheduleID);
            
            CreateTable(
                "dbo.EmployeeDropdowns",
                c => new
                    {
                        employeeID = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.employeeID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID)
                .Index(t => t.Schedule_ScheduleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDropdowns", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.CitizensDropDowns", "Schedule_ScheduleID", "dbo.Schedules");
            DropIndex("dbo.EmployeeDropdowns", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.CitizensDropDowns", new[] { "Schedule_ScheduleID" });
            DropTable("dbo.EmployeeDropdowns");
            DropTable("dbo.CitizensDropDowns");
        }
    }
}
