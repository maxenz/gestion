namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClientesUsuariosSHAMANID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientesUsuarios", "ShamanFullID", c => c.Int());
            AlterColumn("dbo.ClientesUsuarios", "ShamanExpressID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientesUsuarios", "ShamanExpressID", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientesUsuarios", "ShamanFullID", c => c.Int(nullable: false));
        }
    }
}
