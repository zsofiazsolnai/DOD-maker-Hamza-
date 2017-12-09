namespace DOD_Maker_Hamza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOD_Option",
                c => new
                    {
                        DODOptionID = c.Int(nullable: false, identity: true),
                        Option_Text = c.String(),
                        DODTemplateID = c.Int(nullable: false),
                        Type_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DODOptionID)
                .ForeignKey("dbo.DOD_Type", t => t.Type_ID, cascadeDelete: true)
                .ForeignKey("dbo.DODTemplates", t => t.DODTemplateID, cascadeDelete: true)
                .Index(t => t.DODTemplateID)
                .Index(t => t.Type_ID);
            
            CreateTable(
                "dbo.DOD_Type",
                c => new
                    {
                        Type_ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Type_ID);
            
            CreateTable(
                "dbo.DOD_Template_Type",
                c => new
                    {
                        DOD_Template_Type_ID = c.Int(nullable: false, identity: true),
                        DODTemplateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DOD_Template_Type_ID)
                .ForeignKey("dbo.DODTemplates", t => t.DODTemplateID, cascadeDelete: true)
                .Index(t => t.DODTemplateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DOD_Template_Type", "DODTemplateID", "dbo.DODTemplates");
            DropForeignKey("dbo.DOD_Option", "DODTemplateID", "dbo.DODTemplates");
            DropForeignKey("dbo.DOD_Option", "Type_ID", "dbo.DOD_Type");
            DropIndex("dbo.DOD_Template_Type", new[] { "DODTemplateID" });
            DropIndex("dbo.DOD_Option", new[] { "Type_ID" });
            DropIndex("dbo.DOD_Option", new[] { "DODTemplateID" });
            DropTable("dbo.DOD_Template_Type");
            DropTable("dbo.DOD_Type");
            DropTable("dbo.DOD_Option");
        }
    }
}
