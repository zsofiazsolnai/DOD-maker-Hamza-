namespace DOD_Maker_Hamza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DODTemplates",
                c => new
                    {
                        DODTemplateID = c.Int(nullable: false, identity: true),
                        DODTemplate = c.String(),
                    })
                .PrimaryKey(t => t.DODTemplateID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DODTemplates");
        }
    }
}
