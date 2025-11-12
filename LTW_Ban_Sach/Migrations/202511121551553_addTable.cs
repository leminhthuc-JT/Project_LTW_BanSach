namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        VoucherId = c.String(nullable: false, maxLength: 128),
                        VoucherName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VoucherId)
                .ForeignKey("dbo.Events", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.String(nullable: false, maxLength: 128),
                        EventName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.ImageEvents",
                c => new
                    {
                        EventId = c.String(nullable: false, maxLength: 128),
                        ImageEvent = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.EventId, t.ImageEvent })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Bills", "VoucherId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bills", "VoucherId");
            AddForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers", "VoucherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vouchers", "EventId", "dbo.Events");
            DropForeignKey("dbo.ImageEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Bills", "VoucherId", "dbo.Vouchers");
            DropIndex("dbo.ImageEvents", new[] { "EventId" });
            DropIndex("dbo.Vouchers", new[] { "EventId" });
            DropIndex("dbo.Bills", new[] { "VoucherId" });
            DropColumn("dbo.Bills", "VoucherId");
            DropTable("dbo.ImageEvents");
            DropTable("dbo.Events");
            DropTable("dbo.Vouchers");
        }
    }
}
