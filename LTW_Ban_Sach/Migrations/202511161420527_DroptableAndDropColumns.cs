namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroptableAndDropColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.DetailBills", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CateId", "dbo.Categories");
            DropForeignKey("dbo.Vouchers", "EventId", "dbo.Events");
            DropForeignKey("dbo.DetailBills", "BillId", "dbo.Bills");
            DropForeignKey("dbo.ImageEvents", "EventId", "dbo.Events");
            DropIndex("dbo.Bills", new[] { "AccountId" });
            DropIndex("dbo.Bills", new[] { "VoucherId" });
            DropIndex("dbo.DetailBills", new[] { "BillId" });
            DropIndex("dbo.DetailBills", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "CateId" });
            DropIndex("dbo.Vouchers", new[] { "EventId" });
            DropIndex("dbo.ImageEvents", new[] { "EventId" });
            DropPrimaryKey("dbo.Bills");
            DropPrimaryKey("dbo.DetailBills");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Vouchers");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.ImageEvents");
            AddColumn("dbo.DetailBills", "Books_BookId", c => c.Int());
            AlterColumn("dbo.Bills", "BillId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bills", "VoucherId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailBills", "BillId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "BookId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "CateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CateId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Vouchers", "VoucherId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Vouchers", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "EventId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImageEvents", "EventId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Bills", "BillId");
            AddPrimaryKey("dbo.DetailBills", new[] { "BillId", "BookId" });
            AddPrimaryKey("dbo.Books", "BookId");
            AddPrimaryKey("dbo.Categories", "CateId");
            AddPrimaryKey("dbo.Vouchers", "VoucherId");
            AddPrimaryKey("dbo.Events", "EventId");
            AddPrimaryKey("dbo.ImageEvents", new[] { "EventId", "ImageEvent" });
            CreateIndex("dbo.Bills", "VoucherId");
            CreateIndex("dbo.DetailBills", "BillId");
            CreateIndex("dbo.DetailBills", "Books_BookId");
            CreateIndex("dbo.Books", "CateId");
            CreateIndex("dbo.Vouchers", "EventId");
            CreateIndex("dbo.ImageEvents", "EventId");
            AddForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers", "VoucherId", cascadeDelete: true);
            AddForeignKey("dbo.DetailBills", "Books_BookId", "dbo.Books", "BookId");
            AddForeignKey("dbo.Books", "CateId", "dbo.Categories", "CateId", cascadeDelete: true);
            AddForeignKey("dbo.Vouchers", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.DetailBills", "BillId", "dbo.Bills", "BillId", cascadeDelete: true);
            AddForeignKey("dbo.ImageEvents", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            DropColumn("dbo.Bills", "AccountId");
            DropTable("dbo.Accounts");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Bills", "AccountId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ImageEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.DetailBills", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Vouchers", "EventId", "dbo.Events");
            DropForeignKey("dbo.Books", "CateId", "dbo.Categories");
            DropForeignKey("dbo.DetailBills", "Books_BookId", "dbo.Books");
            DropForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers");
            DropIndex("dbo.ImageEvents", new[] { "EventId" });
            DropIndex("dbo.Vouchers", new[] { "EventId" });
            DropIndex("dbo.Books", new[] { "CateId" });
            DropIndex("dbo.DetailBills", new[] { "Books_BookId" });
            DropIndex("dbo.DetailBills", new[] { "BillId" });
            DropIndex("dbo.Bills", new[] { "VoucherId" });
            DropPrimaryKey("dbo.ImageEvents");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Vouchers");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.DetailBills");
            DropPrimaryKey("dbo.Bills");
            AlterColumn("dbo.ImageEvents", "EventId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "EventId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Vouchers", "EventId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vouchers", "VoucherId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "CateId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "CateId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Books", "BookId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DetailBills", "BillId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Bills", "VoucherId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bills", "BillId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.DetailBills", "Books_BookId");
            AddPrimaryKey("dbo.ImageEvents", new[] { "EventId", "ImageEvent" });
            AddPrimaryKey("dbo.Events", "EventId");
            AddPrimaryKey("dbo.Vouchers", "VoucherId");
            AddPrimaryKey("dbo.Categories", "CateId");
            AddPrimaryKey("dbo.Books", "BookId");
            AddPrimaryKey("dbo.DetailBills", new[] { "BillId", "BookId" });
            AddPrimaryKey("dbo.Bills", "BillId");
            CreateIndex("dbo.ImageEvents", "EventId");
            CreateIndex("dbo.Vouchers", "EventId");
            CreateIndex("dbo.Books", "CateId");
            CreateIndex("dbo.DetailBills", "BookId");
            CreateIndex("dbo.DetailBills", "BillId");
            CreateIndex("dbo.Bills", "VoucherId");
            CreateIndex("dbo.Bills", "AccountId");
            AddForeignKey("dbo.ImageEvents", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.DetailBills", "BillId", "dbo.Bills", "BillId", cascadeDelete: true);
            AddForeignKey("dbo.Vouchers", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Books", "CateId", "dbo.Categories", "CateId");
            AddForeignKey("dbo.DetailBills", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers", "VoucherId");
            AddForeignKey("dbo.Bills", "AccountId", "dbo.Accounts", "AccountId");
        }
    }
}
