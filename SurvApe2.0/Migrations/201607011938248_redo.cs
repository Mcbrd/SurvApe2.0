namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Responses", new[] { "QuestionId" });
            DropColumn("dbo.Responses", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responses", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Responses", "QuestionId");
            AddForeignKey("dbo.Responses", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
