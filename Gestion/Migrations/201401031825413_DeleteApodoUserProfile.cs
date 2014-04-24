namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteApodoUserProfile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfile", "Apodo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Apodo", c => c.String());
        }
    }
}
