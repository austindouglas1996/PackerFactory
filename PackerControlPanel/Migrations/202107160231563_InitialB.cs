namespace PackerControlPanel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "ParentID", "dbo.Parts");
            DropForeignKey("dbo.ReceiverEntryDateEntries", "EntryID", "dbo.ReceiverEntries");
            DropIndex("dbo.Parts", new[] { "ParentID" });
            AddForeignKey("dbo.ReceiverEntryDateEntries", "EntryID", "dbo.ReceiverEntries", "ID");
            DropColumn("dbo.Parts", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parts", "ParentID", c => c.Int());
            DropForeignKey("dbo.ReceiverEntryDateEntries", "EntryID", "dbo.ReceiverEntries");
            CreateIndex("dbo.Parts", "ParentID");
            AddForeignKey("dbo.ReceiverEntryDateEntries", "EntryID", "dbo.ReceiverEntries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Parts", "ParentID", "dbo.Parts", "ID");
        }
    }
}
