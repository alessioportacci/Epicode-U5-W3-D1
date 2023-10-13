namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiunteLabelsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Prodotto", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.T_Prodotto", "Costo", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.T_Prodotto", "Ingredienti", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.T_Utenti", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Utenti", "Nome", c => c.String(maxLength: 100));
            AlterColumn("dbo.T_Prodotto", "Ingredienti", c => c.String(maxLength: 400));
            AlterColumn("dbo.T_Prodotto", "Costo", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.T_Prodotto", "Nome", c => c.String(maxLength: 100));
        }
    }
}
