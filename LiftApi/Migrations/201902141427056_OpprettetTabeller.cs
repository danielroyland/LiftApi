namespace LiftApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpprettetTabeller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bruker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrukerId = c.String(),
                        Brukernavn = c.String(),
                        Navn = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Løft",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeLøft = c.Int(nullable: false),
                        AntallReps = c.Int(nullable: false),
                        AntallKg = c.Int(nullable: false),
                        TeoretiskMaks = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Treningsøkt",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dato = c.DateTime(nullable: false),
                        Benkpress_ID = c.Int(),
                        Bruker_ID = c.Int(),
                        Knebøy_ID = c.Int(),
                        Markløft_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Løft", t => t.Benkpress_ID)
                .ForeignKey("dbo.Bruker", t => t.Bruker_ID)
                .ForeignKey("dbo.Løft", t => t.Knebøy_ID)
                .ForeignKey("dbo.Løft", t => t.Markløft_ID)
                .Index(t => t.Benkpress_ID)
                .Index(t => t.Bruker_ID)
                .Index(t => t.Knebøy_ID)
                .Index(t => t.Markløft_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treningsøkt", "Markløft_ID", "dbo.Løft");
            DropForeignKey("dbo.Treningsøkt", "Knebøy_ID", "dbo.Løft");
            DropForeignKey("dbo.Treningsøkt", "Bruker_ID", "dbo.Bruker");
            DropForeignKey("dbo.Treningsøkt", "Benkpress_ID", "dbo.Løft");
            DropIndex("dbo.Treningsøkt", new[] { "Markløft_ID" });
            DropIndex("dbo.Treningsøkt", new[] { "Knebøy_ID" });
            DropIndex("dbo.Treningsøkt", new[] { "Bruker_ID" });
            DropIndex("dbo.Treningsøkt", new[] { "Benkpress_ID" });
            DropTable("dbo.Treningsøkt");
            DropTable("dbo.Løft");
            DropTable("dbo.Bruker");
        }
    }
}
