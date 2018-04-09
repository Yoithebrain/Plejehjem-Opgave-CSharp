namespace Plejehjem_Opgave_CSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCitizens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FullCitizensInfoes",
                c => new
                    {
                        citizensID = c.Int(nullable: false, identity: true),
                        CPRNumber = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        address = c.String(nullable: false),
                        bloodtype = c.String(),
                        sicknesses = c.String(),
                        intolerentTo = c.String(),
                        mentalDisorders = c.String(),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.citizensID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FullCitizensInfoes");
        }
    }
}
