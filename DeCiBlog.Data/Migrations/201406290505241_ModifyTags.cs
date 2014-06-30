namespace DeCiBlog.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagBlogEntries", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagBlogEntries", "BlogEntry_Id", "dbo.BlogEntries");
            DropIndex("dbo.TagBlogEntries", new[] { "Tag_Id" });
            DropIndex("dbo.TagBlogEntries", new[] { "BlogEntry_Id" });
            AddColumn("dbo.BlogEntries", "Tags", c => c.String());
            DropTable("dbo.Tags");
            DropTable("dbo.TagBlogEntries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagBlogEntries",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        BlogEntry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.BlogEntry_Id });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.BlogEntries", "Tags");
            CreateIndex("dbo.TagBlogEntries", "BlogEntry_Id");
            CreateIndex("dbo.TagBlogEntries", "Tag_Id");
            AddForeignKey("dbo.TagBlogEntries", "BlogEntry_Id", "dbo.BlogEntries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagBlogEntries", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
