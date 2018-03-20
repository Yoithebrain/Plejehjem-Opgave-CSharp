namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        visitingTime = c.String(nullable: false),
                        DateForVisiting = c.DateTime(nullable: false),
                        citizensRefId = c.Int(nullable: false),
                        userAccountRef = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.FullCitizensInfoes", t => t.citizensRefId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.userAccountRef, cascadeDelete: true)
                .Index(t => t.citizensRefId)
                .Index(t => t.userAccountRef);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "userAccountRef", "dbo.UserAccounts");
            DropForeignKey("dbo.Schedules", "citizensRefId", "dbo.FullCitizensInfoes");
            DropIndex("dbo.Schedules", new[] { "userAccountRef" });
            DropIndex("dbo.Schedules", new[] { "citizensRefId" });
            DropTable("dbo.Schedules");
        }
    }
}
