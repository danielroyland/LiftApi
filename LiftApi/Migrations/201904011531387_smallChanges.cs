namespace LiftApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Treningsøkt", "Bruker_ID", "dbo.Bruker");
            DropIndex("dbo.Treningsøkt", new[] { "Bruker_ID" });
            AddColumn("dbo.Treningsøkt", "BrukerId", c => c.String());
            AlterColumn("dbo.Løft", "AntallKg", c => c.Double(nullable: false));
            DropColumn("dbo.Treningsøkt", "Bruker_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treningsøkt", "Bruker_ID", c => c.Int());
            AlterColumn("dbo.Løft", "AntallKg", c => c.Int(nullable: false));
            DropColumn("dbo.Treningsøkt", "BrukerId");
            CreateIndex("dbo.Treningsøkt", "Bruker_ID");
            AddForeignKey("dbo.Treningsøkt", "Bruker_ID", "dbo.Bruker", "ID");
        }
    }
}
