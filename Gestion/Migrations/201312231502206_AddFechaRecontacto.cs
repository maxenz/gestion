namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFechaRecontacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientesGestiones", "FechaRecontacto", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientesGestiones", "FechaRecontacto");
        }
    }
}
