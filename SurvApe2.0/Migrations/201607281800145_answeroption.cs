namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answeroption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        AnswerText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AnswerOptions", new[] { "QuestionId" });
            DropTable("dbo.AnswerOptions");
        }
    }
}
