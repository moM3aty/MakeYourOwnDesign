namespace M.Y.O.D.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.menu_item", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.menu_item", "name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
