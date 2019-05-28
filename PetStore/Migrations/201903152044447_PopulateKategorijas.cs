namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateKategorijas : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Kategorijas (Id,Naziv) VALUES (1, 'Psi')");
            Sql("INSERT INTO Kategorijas (Id,Naziv) VALUES (2, 'Macke')");
            Sql("INSERT INTO Kategorijas (Id,Naziv) VALUES (3, 'Male zivotinje')");
            Sql("INSERT INTO Kategorijas (Id,Naziv) VALUES (4, 'Ptice')");
            Sql("INSERT INTO Kategorijas (Id,Naziv) VALUES (5, 'Ribe')");
        }
        
        public override void Down()
        {
        }
    }
}
