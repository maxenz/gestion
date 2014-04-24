namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRevendedorID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "RevendedorID", c => c.Int());
            AddForeignKey("dbo.Clientes", "RevendedorID", "dbo.Revendedores", "ID", cascadeDelete: true);
            CreateIndex("dbo.Clientes", "RevendedorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "RevendedorID" });
            DropForeignKey("dbo.Clientes", "RevendedorID", "dbo.Revendedores");
            DropColumn("dbo.Clientes", "RevendedorID");
        }
    }
}
