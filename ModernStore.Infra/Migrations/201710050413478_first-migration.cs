namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(),
                        Name_LastName = c.String(),
                        Birthdate = c.DateTime(),
                        Email_Address = c.String(),
                        Document_Number = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Number = c.String(),
                        Status = c.Int(nullable: false),
                        DeliveryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        QuantityOnHand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
        }
    }
}
