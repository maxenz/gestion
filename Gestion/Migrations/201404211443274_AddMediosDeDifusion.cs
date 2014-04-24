namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediosDeDifusion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediosDifusion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MapaVisible = c.Boolean(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MediosDifusion");
        }
    }
}
