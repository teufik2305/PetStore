namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassesForNarudzba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Narudzbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        DatumNarudzbe = c.DateTime(nullable: false),
                        NacinPlacanja = c.String(),
                        Status = c.String(),
                        ImeKupca = c.String(),
                        BrojKupca = c.String(),
                        EmailKupca = c.String(),
                        AdresaKupca = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NaruzbaDetaljis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cijena = c.Double(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Igracka_Id = c.Int(),
                        Narudzba_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Igrackas", t => t.Igracka_Id)
                .ForeignKey("dbo.Narudzbas", t => t.Narudzba_Id)
                .Index(t => t.Igracka_Id)
                .Index(t => t.Narudzba_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NaruzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas");
            DropForeignKey("dbo.NaruzbaDetaljis", "Igracka_Id", "dbo.Igrackas");
            DropIndex("dbo.NaruzbaDetaljis", new[] { "Narudzba_Id" });
            DropIndex("dbo.NaruzbaDetaljis", new[] { "Igracka_Id" });
            DropTable("dbo.NaruzbaDetaljis");
            DropTable("dbo.Narudzbas");
        }
    }
}
