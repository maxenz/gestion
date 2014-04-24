namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEditable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TicketEventos", "Editable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketEventos", "Editable", c => c.Boolean(nullable: false));
        }
    }
}
