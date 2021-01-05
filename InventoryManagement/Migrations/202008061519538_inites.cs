namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inites : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Supplier_tSupplierID", "dbo.tSuppliers");
            DropIndex("dbo.Products", new[] { "Supplier_tSupplierID" });
            RenameColumn(table: "dbo.Products", name: "Supplier_tSupplierID", newName: "tSupplierID");
            AlterColumn("dbo.Products", "tSupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "tSupplierID");
            AddForeignKey("dbo.Products", "tSupplierID", "dbo.tSuppliers", "tSupplierID", cascadeDelete: true);
            DropColumn("dbo.Products", "CompanyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CompanyID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "tSupplierID", "dbo.tSuppliers");
            DropIndex("dbo.Products", new[] { "tSupplierID" });
            AlterColumn("dbo.Products", "tSupplierID", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "tSupplierID", newName: "Supplier_tSupplierID");
            CreateIndex("dbo.Products", "Supplier_tSupplierID");
            AddForeignKey("dbo.Products", "Supplier_tSupplierID", "dbo.tSuppliers", "tSupplierID");
        }
    }
}
