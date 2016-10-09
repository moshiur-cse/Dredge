namespace DredgingCodeFastApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistrictModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Division_id = c.String(maxLength: 1000, unicode: false),
                        District_name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DivisionModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Division_name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MauzaModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Union_id = c.String(maxLength: 1000, unicode: false),
                        Mauza_name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnionModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Upazila_id = c.String(maxLength: 1000, unicode: false),
                        Union_name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpazilaModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        District_id = c.String(maxLength: 1000, unicode: false),
                        Upazila_name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpazilaModels");
            DropTable("dbo.UnionModels");
            DropTable("dbo.MauzaModels");
            DropTable("dbo.DivisionModels");
            DropTable("dbo.DistrictModels");
        }
    }
}
