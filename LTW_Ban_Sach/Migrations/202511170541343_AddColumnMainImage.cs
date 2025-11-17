namespace LTW_Ban_Sach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnMainImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "mainImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "mainImage");
        }
    }
}
