namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedNameNarudzbaDetalji : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NaruzbaDetaljis", newName: "NarudzbaDetaljis");
            AddColumn("dbo.NarudzbaDetaljis", "Narudzba_Id", c => c.Int());
            CreateIndex("dbo.NarudzbaDetaljis", "Narudzba_Id");
            AddForeignKey("dbo.NarudzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NarudzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas");
            DropIndex("dbo.NarudzbaDetaljis", new[] { "Narudzba_Id" });
            DropColumn("dbo.NarudzbaDetaljis", "Narudzba_Id");
            RenameTable(name: "dbo.NarudzbaDetaljis", newName: "NaruzbaDetaljis");
        }
    }
}
