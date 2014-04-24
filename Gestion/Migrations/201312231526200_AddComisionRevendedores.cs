namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComisionRevendedores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Revendedores", "Comision", c => c.Double(nullable: false));
            AddColumn("dbo.Revendedores", "BajoContrato", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Revendedores", "BajoContrato");
            DropColumn("dbo.Revendedores", "Comision");
        }
    }
}
