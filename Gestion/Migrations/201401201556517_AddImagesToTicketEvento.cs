namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesToTicketEvento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEventos", "ImageData", c => c.Binary());
            AddColumn("dbo.TicketEventos", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketEventos", "ImageMimeType");
            DropColumn("dbo.TicketEventos", "ImageData");
        }
    }
}
