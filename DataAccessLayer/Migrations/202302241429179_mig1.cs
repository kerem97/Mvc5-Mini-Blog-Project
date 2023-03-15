namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutContent1 = c.String(maxLength: 500),
                        AboutContent2 = c.String(maxLength: 500),
                        AboutImage1 = c.String(maxLength: 100),
                        AboutImage2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 30),
                        Password = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 30),
                        AuthorImage = c.String(maxLength: 100),
                        AuthorAbout = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(maxLength: 100),
                        BlogImage = c.String(maxLength: 100),
                        BlogDate = c.DateTime(nullable: false),
                        BlogContent = c.String(),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        Mail = c.String(maxLength: 50),
                        Content = c.String(maxLength: 300),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        SurName = c.String(maxLength: 30),
                        Mail = c.String(maxLength: 35),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "AuthorID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
