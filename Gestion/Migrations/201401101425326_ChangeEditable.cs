namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketEventos", "Editable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketEventos", "Editable");
        }
    }
}
