namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentText", c => c.String(maxLength: 300));
            DropColumn("dbo.Comments", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Content", c => c.String(maxLength: 300));
            DropColumn("dbo.Comments", "CommentText");
        }
    }
}
