namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableImg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Books_BookId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Books", t => t.Books_BookId)
                .Index(t => t.Books_BookId);
            
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageBooks", "Books_BookId", "dbo.Books");
            DropIndex("dbo.ImageBooks", new[] { "Books_BookId" });
            AlterColumn("dbo.Books", "BookName", c => c.String());
            DropTable("dbo.ImageBooks");
        }
    }
}
