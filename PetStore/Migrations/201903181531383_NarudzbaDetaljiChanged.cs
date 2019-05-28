namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NarudzbaDetaljiChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NaruzbaDetaljis", "Igracka_Id", "dbo.Igrackas");
            DropForeignKey("dbo.NaruzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas");
            DropIndex("dbo.NaruzbaDetaljis", new[] { "Igracka_Id" });
            DropIndex("dbo.NaruzbaDetaljis", new[] { "Narudzba_Id" });
            AddColumn("dbo.NaruzbaDetaljis", "IgrackaId", c => c.Int(nullable: false));
            DropColumn("dbo.NaruzbaDetaljis", "Igracka_Id");
            DropColumn("dbo.NaruzbaDetaljis", "Narudzba_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NaruzbaDetaljis", "Narudzba_Id", c => c.Int());
            AddColumn("dbo.NaruzbaDetaljis", "Igracka_Id", c => c.Int());
            DropColumn("dbo.NaruzbaDetaljis", "IgrackaId");
            CreateIndex("dbo.NaruzbaDetaljis", "Narudzba_Id");
            CreateIndex("dbo.NaruzbaDetaljis", "Igracka_Id");
            AddForeignKey("dbo.NaruzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas", "Id");
            AddForeignKey("dbo.NaruzbaDetaljis", "Igracka_Id", "dbo.Igrackas", "Id");
        }
    }
}
