namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRevendedorTipo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "RevendedorID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "RevendedorID", c => c.Int(nullable: false));
        }
    }
}
