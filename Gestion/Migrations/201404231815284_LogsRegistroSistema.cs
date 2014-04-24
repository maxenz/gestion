namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogsRegistroSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogsRegistrosSistema",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        DescripcionAccion = c.String(nullable: false),
                        ObservacionesAccion = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogsRegistrosSistema", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.LogsRegistrosSistema", new[] { "UsuarioID" });
            DropTable("dbo.LogsRegistrosSistema");
        }
    }
}
