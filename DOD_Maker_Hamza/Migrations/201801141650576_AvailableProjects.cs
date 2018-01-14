namespace DOD_Maker_Hamza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailableProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableProjects",
                c => new
                    {
                        AvailableProjectID = c.Int(nullable: false, identity: true),
                        AvailableProjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AvailableProjectID);
            
            AddColumn("dbo.MyDODs", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.MyDODs", "AvailableProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.MyDODs", "UserID");
            CreateIndex("dbo.MyDODs", "AvailableProjectID");
            AddForeignKey("dbo.MyDODs", "AvailableProjectID", "dbo.AvailableProjects", "AvailableProjectID", cascadeDelete: true);
            AddForeignKey("dbo.MyDODs", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.MyDODs", "OwnerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyDODs", "OwnerName", c => c.String());
            DropForeignKey("dbo.MyDODs", "UserID", "dbo.Users");
            DropForeignKey("dbo.MyDODs", "AvailableProjectID", "dbo.AvailableProjects");
            DropIndex("dbo.MyDODs", new[] { "AvailableProjectID" });
            DropIndex("dbo.MyDODs", new[] { "UserID" });
            DropColumn("dbo.MyDODs", "AvailableProjectID");
            DropColumn("dbo.MyDODs", "UserID");
            DropTable("dbo.AvailableProjects");
        }
    }
}
