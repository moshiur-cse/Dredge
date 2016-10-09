namespace DredgingCodeFastApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versino3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MauzaModels", "Dredger_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MauzaModels", "Dredger_id");
        }
    }
}
