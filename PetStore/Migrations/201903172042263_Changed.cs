namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.IgrackaFormViewModels");
        }
    }
}
