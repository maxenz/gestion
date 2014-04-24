namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRequiredServidorLicencia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientesLicencias", "ConexionServidor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientesLicencias", "ConexionServidor", c => c.String(nullable: false));
        }
    }
}
