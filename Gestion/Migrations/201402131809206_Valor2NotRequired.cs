namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valor2NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientesTerminales", "Valor2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientesTerminales", "Valor2", c => c.String(nullable: false));
        }
    }
}
