namespace StoreAPB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        recordid = c.Int(nullable: false, identity: true),
                        cartid = c.String(),
                        count = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        productid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.recordid)
                .ForeignKey("dbo.Product", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        productid = c.Int(nullable: false),
                        name_p = c.String(nullable: false),
                        image = c.String(),
                        description = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        reduce = c.Decimal(nullable: false, precision: 18, scale: 2),
                        amount = c.Int(nullable: false),
                        type = c.String(),
                        categoryid = c.Int(nullable: false),
                        brand = c.String(),
                        provider = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.productid)
                .ForeignKey("dbo.Category", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        categoryid = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.categoryid);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        orderid = c.Int(nullable: false, identity: true),
                        customer = c.String(),
                        date = c.DateTime(nullable: false),
                        date_check = c.DateTime(nullable: false),
                        phone_number = c.Int(nullable: false),
                        delivery_Address = c.String(),
                        totalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_productid = c.Int(),
                    })
                .PrimaryKey(t => t.orderid)
                .ForeignKey("dbo.Product", t => t.Product_productid)
                .Index(t => t.Product_productid);
            
            CreateTable(
                "dbo.OrderLine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        count = c.Int(nullable: false),
                        productid = c.Int(nullable: false),
                        orderid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.orderid, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid)
                .Index(t => t.orderid);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "productid", "dbo.Product");
            DropForeignKey("dbo.Order", "Product_productid", "dbo.Product");
            DropForeignKey("dbo.OrderLine", "productid", "dbo.Product");
            DropForeignKey("dbo.OrderLine", "orderid", "dbo.Order");
            DropForeignKey("dbo.Product", "categoryid", "dbo.Category");
            DropIndex("dbo.OrderLine", new[] { "orderid" });
            DropIndex("dbo.OrderLine", new[] { "productid" });
            DropIndex("dbo.Order", new[] { "Product_productid" });
            DropIndex("dbo.Product", new[] { "categoryid" });
            DropIndex("dbo.Cart", new[] { "productid" });
            DropTable("dbo.OrderLine");
            DropTable("dbo.Order");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Cart");
        }
    }
}
