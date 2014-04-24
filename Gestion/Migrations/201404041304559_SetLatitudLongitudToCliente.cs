namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetLatitudLongitudToCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Latitud", c => c.Double());
            AddColumn("dbo.Clientes", "Longitud", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Longitud");
            DropColumn("dbo.Clientes", "Latitud");
        }
    }
}
