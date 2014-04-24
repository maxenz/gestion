namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNombreApellidoUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "Nombre", c => c.String());
            AddColumn("dbo.UserProfile", "Apellido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "Apellido");
            DropColumn("dbo.UserProfile", "Nombre");
        }
    }
}
