namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sitios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sitios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sitios");
        }
    }
}
