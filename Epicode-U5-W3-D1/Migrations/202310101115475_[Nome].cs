namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.T_Ordine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indirizzo = c.String(maxLength: 200),
                        DataOrdine = c.DateTime(),
                        DataArrivo = c.DateTime(),
                        Note = c.String(maxLength: 300),
                        Evaso = c.Boolean(),
                        FkUtente = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Utenti", t => t.FkUtente)
                .Index(t => t.FkUtente);
            
            CreateTable(
                "dbo.T_OrdineProdotto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FkOrdine = c.Int(),
                        FkProdotto = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Prodotto", t => t.FkProdotto)
                .ForeignKey("dbo.T_Ordine", t => t.FkOrdine)
                .Index(t => t.FkOrdine)
                .Index(t => t.FkProdotto);
            
            CreateTable(
                "dbo.T_Prodotto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Img = c.String(maxLength: 50),
                        Costo = c.Decimal(storeType: "money"),
                        Ingredienti = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Utenti",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Ruolo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Ordine", "FkUtente", "dbo.T_Utenti");
            DropForeignKey("dbo.T_OrdineProdotto", "FkOrdine", "dbo.T_Ordine");
            DropForeignKey("dbo.T_OrdineProdotto", "FkProdotto", "dbo.T_Prodotto");
            DropIndex("dbo.T_OrdineProdotto", new[] { "FkProdotto" });
            DropIndex("dbo.T_OrdineProdotto", new[] { "FkOrdine" });
            DropIndex("dbo.T_Ordine", new[] { "FkUtente" });
            DropTable("dbo.T_Utenti");
            DropTable("dbo.T_Prodotto");
            DropTable("dbo.T_OrdineProdotto");
            DropTable("dbo.T_Ordine");
            DropTable("dbo.sysdiagrams");
        }
    }
}
