namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAgain : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.IgrackaFormViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IgrackaFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 255),
                        KategorijaId = c.Byte(nullable: false),
                        Opis = c.String(nullable: false),
                        Cijena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
