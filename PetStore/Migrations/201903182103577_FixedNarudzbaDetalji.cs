namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedNarudzbaDetalji : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.NarudzbaDetaljis", "IgrackaId");
            AddForeignKey("dbo.NarudzbaDetaljis", "IgrackaId", "dbo.Igrackas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NarudzbaDetaljis", "IgrackaId", "dbo.Igrackas");
            DropIndex("dbo.NarudzbaDetaljis", new[] { "IgrackaId" });
        }
    }
}
