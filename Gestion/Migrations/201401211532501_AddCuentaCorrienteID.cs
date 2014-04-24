namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCuentaCorrienteID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "CuentaCorrienteID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "CuentaCorrienteID");
        }
    }
}
