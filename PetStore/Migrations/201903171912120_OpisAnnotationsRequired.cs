namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpisAnnotationsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Igrackas", "Opis", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Igrackas", "Opis", c => c.String());
        }
    }
}
