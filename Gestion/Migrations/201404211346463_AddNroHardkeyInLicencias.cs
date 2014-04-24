namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNroHardkeyInLicencias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licencias", "NumeroDeLlave", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Licencias", "NumeroDeLlave");
        }
    }
}
