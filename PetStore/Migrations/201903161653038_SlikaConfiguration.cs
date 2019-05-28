namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlikaConfiguration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Igrackas", "SlikaPath", c => c.String());
            DropColumn("dbo.Igrackas", "Slika");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Igrackas", "Slika", c => c.Binary());
            DropColumn("dbo.Igrackas", "SlikaPath");
        }
    }
}
