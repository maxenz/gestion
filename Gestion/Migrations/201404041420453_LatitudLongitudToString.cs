namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatitudLongitudToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Latitud", c => c.String());
            AlterColumn("dbo.Clientes", "Longitud", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Longitud", c => c.Double());
            AlterColumn("dbo.Clientes", "Latitud", c => c.Double());
        }
    }
}
