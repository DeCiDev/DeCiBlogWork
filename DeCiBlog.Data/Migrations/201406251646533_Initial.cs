namespace DeCiBlog.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Text = c.String(nullable: false, maxLength: 2000),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 600),
                        Url = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        Created = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        BlogEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BlogEntryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinkBlogEntries",
                c => new
                    {
                        Link_Id = c.Int(nullable: false),
                        BlogEntry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Link_Id, t.BlogEntry_Id })
                .ForeignKey("dbo.Links", t => t.Link_Id, cascadeDelete: true)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_Id, cascadeDelete: true)
                .Index(t => t.Link_Id)
                .Index(t => t.BlogEntry_Id);
            
            CreateTable(
                "dbo.CategoryBlogEntries",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        BlogEntry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.BlogEntry_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.BlogEntry_Id);
            
            CreateTable(
                "dbo.TagBlogEntries",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        BlogEntry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.BlogEntry_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.BlogEntry_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagBlogEntries", "BlogEntry_Id", "dbo.BlogEntries");
            DropForeignKey("dbo.TagBlogEntries", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.BlogEntries", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "BlogEntryId", "dbo.BlogEntries");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoryBlogEntries", "BlogEntry_Id", "dbo.BlogEntries");
            DropForeignKey("dbo.CategoryBlogEntries", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.LinkBlogEntries", "BlogEntry_Id", "dbo.BlogEntries");
            DropForeignKey("dbo.LinkBlogEntries", "Link_Id", "dbo.Links");
            DropIndex("dbo.TagBlogEntries", new[] { "BlogEntry_Id" });
            DropIndex("dbo.TagBlogEntries", new[] { "Tag_Id" });
            DropIndex("dbo.CategoryBlogEntries", new[] { "BlogEntry_Id" });
            DropIndex("dbo.CategoryBlogEntries", new[] { "Category_Id" });
            DropIndex("dbo.LinkBlogEntries", new[] { "BlogEntry_Id" });
            DropIndex("dbo.LinkBlogEntries", new[] { "Link_Id" });
            DropIndex("dbo.Comments", new[] { "BlogEntryId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.BlogEntries", new[] { "CreatorId" });
            DropTable("dbo.TagBlogEntries");
            DropTable("dbo.CategoryBlogEntries");
            DropTable("dbo.LinkBlogEntries");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Links");
            DropTable("dbo.BlogEntries");
        }
    }
}
