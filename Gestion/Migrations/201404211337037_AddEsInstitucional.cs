namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEsInstitucional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientesContactos", "esInstitucional", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientesContactos", "esInstitucional");
        }
    }
}
