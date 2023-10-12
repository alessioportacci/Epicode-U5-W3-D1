namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_OrdineProdotto", "FkProdotto", "dbo.T_Prodotto");
            DropForeignKey("dbo.T_OrdineProdotto", "FkOrdine", "dbo.T_Ordine");
            DropIndex("dbo.T_OrdineProdotto", new[] { "FkOrdine" });
            DropIndex("dbo.T_OrdineProdotto", new[] { "FkProdotto" });

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.T_OrdineProdotto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FkOrdine = c.Int(),
                        FkProdotto = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.__MigrationHistory");
            CreateIndex("dbo.T_OrdineProdotto", "FkProdotto");
            CreateIndex("dbo.T_OrdineProdotto", "FkOrdine");
            AddForeignKey("dbo.T_OrdineProdotto", "FkOrdine", "dbo.T_Ordine", "Id");
            AddForeignKey("dbo.T_OrdineProdotto", "FkProdotto", "dbo.T_Prodotto", "Id");
        }
    }
}
