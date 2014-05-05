namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPdfGestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientesGestiones", "PdfGestion", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientesGestiones", "PdfGestion");
        }
    }
}
