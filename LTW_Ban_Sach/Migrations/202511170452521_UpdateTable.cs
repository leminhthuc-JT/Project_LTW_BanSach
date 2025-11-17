namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageBooks", "Books_BookId", "dbo.Books");
            DropIndex("dbo.ImageBooks", new[] { "Books_BookId" });
            CreateTable(
                "dbo.ImagesBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.BookId, t.ImageUrl })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            DropTable("dbo.ImageBooks");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.BookId);
            
            DropForeignKey("dbo.ImagesBooks", "BookId", "dbo.Books");
            DropIndex("dbo.ImagesBooks", new[] { "BookId" });
            DropTable("dbo.ImagesBooks");
            CreateIndex("dbo.ImageBooks", "Books_BookId");
            AddForeignKey("dbo.ImageBooks", "Books_BookId", "dbo.Books", "BookId");
        }
    }
}
