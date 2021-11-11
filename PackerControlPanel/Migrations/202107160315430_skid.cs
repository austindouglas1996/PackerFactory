namespace PackerControlPanel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skid : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Parts", "ParentID", "dbo.Parts");
            //DropIndex("dbo.Parts", new[] { "ParentID" });
            CreateTable(
                "dbo.Skids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.JobID)
                .ForeignKey("dbo.Parts", t => t.PartID)
                .Index(t => t.PartID)
                .Index(t => t.JobID);
            
            //DropColumn("dbo.Parts", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parts", "ParentID", c => c.Int());
            DropForeignKey("dbo.Skids", "PartID", "dbo.Parts");
            DropForeignKey("dbo.Skids", "JobID", "dbo.Jobs");
            DropIndex("dbo.Skids", new[] { "JobID" });
            DropIndex("dbo.Skids", new[] { "PartID" });
            DropTable("dbo.Skids");
            CreateIndex("dbo.Parts", "ParentID");
            AddForeignKey("dbo.Parts", "ParentID", "dbo.Parts", "ID");
        }
    }
}
