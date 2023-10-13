namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiuntoControlloLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Utenti", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.T_Utenti", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Utenti", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.T_Utenti", "Username", c => c.String(maxLength: 50));
        }
    }
}
