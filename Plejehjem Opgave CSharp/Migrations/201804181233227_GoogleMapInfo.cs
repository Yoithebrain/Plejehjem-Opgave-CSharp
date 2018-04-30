namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoogleMapInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoogleMapsInformations",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longtitude = c.Double(nullable: false),
                        mapsRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.FullCitizensInfoes", t => t.mapsRefId, cascadeDelete: true)
                .Index(t => t.mapsRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoogleMapsInformations", "mapsRefId", "dbo.FullCitizensInfoes");
            DropIndex("dbo.GoogleMapsInformations", new[] { "mapsRefId" });
            DropTable("dbo.GoogleMapsInformations");
        }
    }
}
