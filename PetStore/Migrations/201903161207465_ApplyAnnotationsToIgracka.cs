namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToIgracka : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Igrackas", "Naziv", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Igrackas", "Naziv", c => c.String());
        }
    }
}
