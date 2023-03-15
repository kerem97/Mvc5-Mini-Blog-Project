namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_author_extras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorAboutShort", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorPhoneNumber", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPhoneNumber");
            DropColumn("dbo.Authors", "AuthorPassword");
            DropColumn("dbo.Authors", "AuthorMail");
            DropColumn("dbo.Authors", "AuthorAboutShort");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
