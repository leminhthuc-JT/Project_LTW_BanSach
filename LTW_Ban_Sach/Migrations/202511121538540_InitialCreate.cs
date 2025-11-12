namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        AccountName = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Member = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.String(nullable: false, maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.DetailBills",
                c => new
                    {
                        BillId = c.String(nullable: false, maxLength: 128),
                        BookId = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BillId, t.BookId })
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.String(nullable: false, maxLength: 128),
                        BookName = c.String(),
                        Author = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PublicationYear = c.Int(nullable: false),
                        Publisher = c.String(),
                        Description = c.String(),
                        CateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Categories", t => t.CateId)
                .Index(t => t.CateId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.String(nullable: false, maxLength: 128),
                        CateName = c.String(),
                    })
                .PrimaryKey(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailBills", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CateId", "dbo.Categories");
            DropForeignKey("dbo.DetailBills", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Bills", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Books", new[] { "CateId" });
            DropIndex("dbo.DetailBills", new[] { "BookId" });
            DropIndex("dbo.DetailBills", new[] { "BillId" });
            DropIndex("dbo.Bills", new[] { "AccountId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.DetailBills");
            DropTable("dbo.Bills");
            DropTable("dbo.Accounts");
        }
    }
}
