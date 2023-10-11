namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedT_Ordine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Ordine", "FkProdtto", c => c.Int());
            AddColumn("dbo.T_Ordine", "Quantita", c => c.Int(nullable: false));
            AddColumn("dbo.T_Ordine", "T_Prodotto_Id", c => c.Int());
            AlterColumn("dbo.T_Ordine", "Evaso", c => c.Boolean(nullable: false));
            CreateIndex("dbo.T_Ordine", "T_Prodotto_Id");
            AddForeignKey("dbo.T_Ordine", "T_Prodotto_Id", "dbo.T_Prodotto", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Ordine", "T_Prodotto_Id", "dbo.T_Prodotto");
            DropIndex("dbo.T_Ordine", new[] { "T_Prodotto_Id" });
            AlterColumn("dbo.T_Ordine", "Evaso", c => c.Boolean());
            DropColumn("dbo.T_Ordine", "T_Prodotto_Id");
            DropColumn("dbo.T_Ordine", "Quantita");
            DropColumn("dbo.T_Ordine", "FkProdtto");
        }
    }
}
