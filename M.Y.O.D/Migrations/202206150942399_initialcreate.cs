namespace M.Y.O.D.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cat = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.menu_item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        price = c.Single(nullable: false),
                        Description = c.String(),
                        Path = c.String(),
                        CatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CatID, cascadeDelete: true)
                .Index(t => t.CatID);
            
            CreateTable(
                "dbo.logIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        pwd = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 15),
                        Lname = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        pwd = c.String(nullable: false),
                        Cpwd = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.menu_item", "CatID", "dbo.Categories");
            DropIndex("dbo.menu_item", new[] { "CatID" });
            DropTable("dbo.Registers");
            DropTable("dbo.logIns");
            DropTable("dbo.menu_item");
            DropTable("dbo.Categories");
        }
    }
}
