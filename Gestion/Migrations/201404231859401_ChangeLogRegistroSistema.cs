namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLogRegistroSistema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LogsRegistrosSistema", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.LogsRegistrosSistema", new[] { "UsuarioID" });
            AddColumn("dbo.LogsRegistrosSistema", "UserProfileID", c => c.Int(nullable: false));
            CreateIndex("dbo.LogsRegistrosSistema", "UserProfileID");
            AddForeignKey("dbo.LogsRegistrosSistema", "UserProfileID", "dbo.UserProfile", "UserId", cascadeDelete: true);
            DropColumn("dbo.LogsRegistrosSistema", "UsuarioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogsRegistrosSistema", "UsuarioID", c => c.Int(nullable: false));
            DropForeignKey("dbo.LogsRegistrosSistema", "UserProfileID", "dbo.UserProfile");
            DropIndex("dbo.LogsRegistrosSistema", new[] { "UserProfileID" });
            DropColumn("dbo.LogsRegistrosSistema", "UserProfileID");
            CreateIndex("dbo.LogsRegistrosSistema", "UsuarioID");
            AddForeignKey("dbo.LogsRegistrosSistema", "UsuarioID", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
    }
}
