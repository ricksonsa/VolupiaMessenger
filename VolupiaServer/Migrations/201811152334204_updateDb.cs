namespace VolupiaServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Username", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "Password", c => c.String());
        }
    }
}
