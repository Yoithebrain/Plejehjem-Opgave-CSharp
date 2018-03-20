namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCitizensContract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitizensContacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        email = c.String(),
                        otherInformation = c.String(),
                        relationToCitizens = c.String(),
                        citizensRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.FullCitizensInfoes", t => t.citizensRefId, cascadeDelete: true)
                .Index(t => t.citizensRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CitizensContacts", "citizensRefId", "dbo.FullCitizensInfoes");
            DropIndex("dbo.CitizensContacts", new[] { "citizensRefId" });
            DropTable("dbo.CitizensContacts");
        }
    }
}
