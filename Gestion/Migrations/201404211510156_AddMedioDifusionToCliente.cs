namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedioDifusionToCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "MedioDifusionID", c => c.Int());
            AddForeignKey("dbo.Clientes", "MedioDifusionID", "dbo.MediosDifusion", "ID");
            CreateIndex("dbo.Clientes", "MedioDifusionID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "MedioDifusionID" });
            DropForeignKey("dbo.Clientes", "MedioDifusionID", "dbo.MediosDifusion");
            DropColumn("dbo.Clientes", "MedioDifusionID");
        }
    }
}
