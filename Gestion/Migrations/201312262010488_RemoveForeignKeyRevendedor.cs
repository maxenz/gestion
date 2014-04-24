namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveForeignKeyRevendedor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "RevendedorID", "dbo.Revendedores");
            DropIndex("dbo.Clientes", new[] { "RevendedorID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Clientes", "RevendedorID");
            AddForeignKey("dbo.Clientes", "RevendedorID", "dbo.Revendedores", "ID", cascadeDelete: true);
        }
    }
}
