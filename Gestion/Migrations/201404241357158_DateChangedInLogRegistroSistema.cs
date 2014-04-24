namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateChangedInLogRegistroSistema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogsRegistrosSistema", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogsRegistrosSistema", "Fecha");
        }
    }
}
