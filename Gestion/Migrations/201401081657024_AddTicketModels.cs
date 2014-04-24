namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Asunto = c.String(nullable: false),
                        Resuelto = c.Boolean(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        TicketEstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfile", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.TicketEstados", t => t.TicketEstadoID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.TicketEstadoID);
            
            CreateTable(
                "dbo.TicketEventos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        TicketTipoEventoID = c.Int(nullable: false),
                        TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TicketTipoEventos", t => t.TicketTipoEventoID, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.TicketTipoEventoID)
                .Index(t => t.TicketID);
            
            CreateTable(
                "dbo.TicketTipoEventos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TicketEstados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TicketEventos", new[] { "TicketID" });
            DropIndex("dbo.TicketEventos", new[] { "TicketTipoEventoID" });
            DropIndex("dbo.Tickets", new[] { "TicketEstadoID" });
            DropIndex("dbo.Tickets", new[] { "UsuarioID" });
            DropForeignKey("dbo.TicketEventos", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.TicketEventos", "TicketTipoEventoID", "dbo.TicketTipoEventos");
            DropForeignKey("dbo.Tickets", "TicketEstadoID", "dbo.TicketEstados");
            DropForeignKey("dbo.Tickets", "UsuarioID", "dbo.UserProfile");
            DropTable("dbo.TicketEstados");
            DropTable("dbo.TicketTipoEventos");
            DropTable("dbo.TicketEventos");
            DropTable("dbo.Tickets");
        }
    }
}
