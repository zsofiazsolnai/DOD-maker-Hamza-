namespace DOD_Maker_Hamza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savingMyDODs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyDODs",
                c => new
                    {
                        MyDODs_ID = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                        MyDOD = c.String(),
                    })
                .PrimaryKey(t => t.MyDODs_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyDODs");
        }
    }
}
