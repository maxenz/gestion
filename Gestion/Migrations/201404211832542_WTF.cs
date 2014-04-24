namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WTF : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "FechaIngreso", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ClientesLicencias", "FechaDeVencimiento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientesLicencias", "FechaDeVencimiento", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.Clientes", "FechaIngreso", c => c.DateTime(nullable: false, storeType: "datetime2"));
        }
    }
}
