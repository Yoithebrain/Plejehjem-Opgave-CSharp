namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedForeignKeyGoogleMapsInfo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GoogleMapsInformations", name: "mapsRefId", newName: "citizensRefId");
            RenameIndex(table: "dbo.GoogleMapsInformations", name: "IX_mapsRefId", newName: "IX_citizensRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GoogleMapsInformations", name: "IX_citizensRefId", newName: "IX_mapsRefId");
            RenameColumn(table: "dbo.GoogleMapsInformations", name: "citizensRefId", newName: "mapsRefId");
        }
    }
}
