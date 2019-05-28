namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToKategorija : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kategorijas", "Naziv", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kategorijas", "Naziv", c => c.String());
        }
    }
}
