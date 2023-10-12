namespace Epicode_U5_W3_D1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedT_OrdineProdotto : DbMigration
    {
        public override void Up()
        {
            DropTable("T_OrdineProdotto");
        }
        
        public override void Down()
        {
        }
    }
}
