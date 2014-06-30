namespace DeCiBlog.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDisabledColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsDisabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDisabled");
        }
    }
}
