namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CitizensDropDowns", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.EmployeeDropdowns", "Schedule_ScheduleID", "dbo.Schedules");
            DropIndex("dbo.CitizensDropDowns", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.EmployeeDropdowns", new[] { "Schedule_ScheduleID" });
            DropTable("dbo.CitizensDropDowns");
            DropTable("dbo.EmployeeDropdowns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeDropdowns",
                c => new
                    {
                        employeeID = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.employeeID);
            
            CreateTable(
                "dbo.CitizensDropDowns",
                c => new
                    {
                        citizensID = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.citizensID);
            
            CreateIndex("dbo.EmployeeDropdowns", "Schedule_ScheduleID");
            CreateIndex("dbo.CitizensDropDowns", "Schedule_ScheduleID");
            AddForeignKey("dbo.EmployeeDropdowns", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
            AddForeignKey("dbo.CitizensDropDowns", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
        }
    }
}
