namespace M.Y.O.D.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.menu_item", "name");
            DropColumn("dbo.menu_item", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.menu_item", "Description", c => c.String());
            AddColumn("dbo.menu_item", "name", c => c.String(nullable: false));
        }
    }
}
