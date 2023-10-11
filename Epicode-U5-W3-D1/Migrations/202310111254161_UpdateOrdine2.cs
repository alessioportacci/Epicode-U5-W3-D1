namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrdine2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Ordine", "Confermato", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Ordine", "FkProdotto", c => c.Int());
            DropColumn("dbo.T_Ordine", "FkProdtto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Ordine", "FkProdtto", c => c.Int());
            DropColumn("dbo.T_Ordine", "FkProdotto");
            DropColumn("dbo.T_Ordine", "Confermato");
        }
    }
}
