namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ProductExpDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        Supplier_tSupplierID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.tSuppliers", t => t.Supplier_tSupplierID)
                .Index(t => t.Supplier_tSupplierID);
            
            CreateTable(
                "dbo.tSuppliers",
                c => new
                    {
                        tSupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        MobileNO = c.String(),
                    })
                .PrimaryKey(t => t.tSupplierID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_tSupplierID", "dbo.tSuppliers");
            DropIndex("dbo.Products", new[] { "Supplier_tSupplierID" });
            DropTable("dbo.Users");
            DropTable("dbo.tSuppliers");
            DropTable("dbo.Products");
        }
    }
}
