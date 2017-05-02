namespace ShangriLa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        PlayerName = c.String(),
                        TotalScore = c.Int(nullable: false),
                        TwoSetsOneRun = c.Int(nullable: false),
                        TwoRunsOneSet = c.Int(nullable: false),
                        ThreeSets = c.Int(nullable: false),
                        ThreeRuns = c.Int(nullable: false),
                        ThreeSetsOneRun = c.Int(nullable: false),
                        TwoSetsTwoRuns = c.Int(nullable: false),
                        FourSets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlayers", "GameId", "dbo.Games");
            DropIndex("dbo.GamePlayers", new[] { "GameId" });
            DropTable("dbo.Players");
            DropTable("dbo.Games");
            DropTable("dbo.GamePlayers");
        }
    }
}
