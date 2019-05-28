namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNarudzbaDetalji : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NarudzbaDetaljis", "IgrackaId", "dbo.Igrackas");
            DropForeignKey("dbo.NarudzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas");
            DropIndex("dbo.NarudzbaDetaljis", new[] { "IgrackaId" });
            DropIndex("dbo.NarudzbaDetaljis", new[] { "Narudzba_Id" });
            RenameColumn(table: "dbo.NarudzbaDetaljis", name: "Narudzba_Id", newName: "NarudzbaId");
            AlterColumn("dbo.NarudzbaDetaljis", "NarudzbaId", c => c.Int(nullable: false));
            CreateIndex("dbo.NarudzbaDetaljis", "NarudzbaId");
            AddForeignKey("dbo.NarudzbaDetaljis", "NarudzbaId", "dbo.Narudzbas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NarudzbaDetaljis", "NarudzbaId", "dbo.Narudzbas");
            DropIndex("dbo.NarudzbaDetaljis", new[] { "NarudzbaId" });
            AlterColumn("dbo.NarudzbaDetaljis", "NarudzbaId", c => c.Int());
            RenameColumn(table: "dbo.NarudzbaDetaljis", name: "NarudzbaId", newName: "Narudzba_Id");
            CreateIndex("dbo.NarudzbaDetaljis", "Narudzba_Id");
            CreateIndex("dbo.NarudzbaDetaljis", "IgrackaId");
            AddForeignKey("dbo.NarudzbaDetaljis", "Narudzba_Id", "dbo.Narudzbas", "Id");
            AddForeignKey("dbo.NarudzbaDetaljis", "IgrackaId", "dbo.Igrackas", "Id", cascadeDelete: true);
        }
    }
}
