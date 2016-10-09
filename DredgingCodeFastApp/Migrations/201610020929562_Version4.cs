namespace DredgingCodeFastApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DredgeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DredgeModels");
        }
    }
}
