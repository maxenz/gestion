namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIDToTicketEvento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEventos", "UsuarioID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketEventos", "UsuarioID");
        }
    }
}
