namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTicketEventoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEventos", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.TicketEventos", "UserID");
            DropColumn("dbo.TicketEventos", "UsuarioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketEventos", "UsuarioID", c => c.Int(nullable: false));
            DropIndex("dbo.TicketEventos", new[] { "UserID" });
            DropColumn("dbo.TicketEventos", "UserID");
        }
    }
}
