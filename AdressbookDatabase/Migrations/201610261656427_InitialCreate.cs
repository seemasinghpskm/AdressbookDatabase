namespace AdressbookDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        ForstaNamn = c.String(),
                        EfterNamn = c.String(),
                        Gatudress = c.String(),
                        PostNummer = c.String(),
                        Postort = c.String(),
                        Telefon = c.String(),
                        Epost = c.String(),
                        Fodelsedag = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}
