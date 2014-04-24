namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClientesUsuarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientesUsuarios", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.ClientesUsuarios", new[] { "UsuarioID" });
            AddForeignKey("dbo.ClientesUsuarios", "UsuarioID", "dbo.UserProfile", "UserId", cascadeDelete: true);
            CreateIndex("dbo.ClientesUsuarios", "UsuarioID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientesUsuarios", new[] { "UsuarioID" });
            DropForeignKey("dbo.ClientesUsuarios", "UsuarioID", "dbo.UserProfile");
            CreateIndex("dbo.ClientesUsuarios", "UsuarioID");
            AddForeignKey("dbo.ClientesUsuarios", "UsuarioID", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
    }
}
