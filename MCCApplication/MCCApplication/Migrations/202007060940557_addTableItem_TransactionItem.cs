namespace MCCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableItem_TransactionItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Item",
                c => new
                    {
                        IdItem = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Price = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdItem)
                .ForeignKey("dbo.TB_M_Supplier", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_TransactionItem",
                c => new
                    {
                        IdTI = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        IdItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTI)
                .ForeignKey("dbo.TB_M_Item", t => t.IdItem, cascadeDelete: true)
                .Index(t => t.IdItem);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_TransactionItem", "IdItem", "dbo.TB_M_Item");
            DropForeignKey("dbo.TB_M_Item", "Id", "dbo.TB_M_Supplier");
            DropIndex("dbo.TB_M_TransactionItem", new[] { "IdItem" });
            DropIndex("dbo.TB_M_Item", new[] { "Id" });
            DropTable("dbo.TB_M_TransactionItem");
            DropTable("dbo.TB_M_Item");
        }
    }
}
