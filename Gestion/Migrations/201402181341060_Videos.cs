namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Videos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                        esPublico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VideosClientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        VideoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.VideoID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.VideosClientes", new[] { "VideoID" });
            DropIndex("dbo.VideosClientes", new[] { "ClienteID" });
            DropForeignKey("dbo.VideosClientes", "VideoID", "dbo.Videos");
            DropForeignKey("dbo.VideosClientes", "ClienteID", "dbo.Clientes");
            DropTable("dbo.VideosClientes");
            DropTable("dbo.Videos");
        }
    }
}
