namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientesContactosValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientesContactos", "Otros", c => c.String());
            AlterColumn("dbo.ClientesContactos", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientesContactos", "Email", c => c.String(nullable: false));
            DropColumn("dbo.ClientesContactos", "Otros");
        }
    }
}
