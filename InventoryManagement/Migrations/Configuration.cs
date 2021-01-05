namespace InventoryManagement.Migrations
{
    using InventoryManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManagement.Models.MyContextDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryManagement.Models.MyContextDb context)
        {
            context.Products.AddOrUpdate(x => x.ProductID,
              new Product() { ProductID=1, ProductName = "Pepsudent", Price =100, Quantity=50, ProductExpDate = System.DateTime.Parse("2005-09-01"), IsDeleted=false, tSupplierID=1},
              new Product() { ProductID=2, ProductName = "Closeup", Price = 100, Quantity = 50, ProductExpDate = System.DateTime.Parse("2005-09-01"), IsDeleted = false, tSupplierID = 2 },
              new Product() { ProductID=3, ProductName = "Colget", Price = 100, Quantity = 50, ProductExpDate = System.DateTime.Parse("2005-09-01"), IsDeleted = false, tSupplierID = 3 }
            );

            context.Suppliers.AddOrUpdate(x => x.tSupplierID,
            new tSupplier() { tSupplierID=1, CompanyName="Square", CompanyAddress="Dhaka", MobileNO="0011223344"},
            new tSupplier() { tSupplierID=2, CompanyName="Akiz", CompanyAddress="Gazipur", MobileNO ="11223344"},
            new tSupplier() { tSupplierID=3, CompanyName="Pran", CompanyAddress="Savar", MobileNO ="0011223344"}
            );

            context.Users.AddOrUpdate(x => x.UserID,
            new User() { UserID=1, UserName="shuvo", Password="Shuvo2244", Role="Admin"},
            new User() { UserID=2, UserName="imran", Password="Imran2244", Role ="Hr"}
            );
        }
    }
}
