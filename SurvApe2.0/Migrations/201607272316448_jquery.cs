namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jquery : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "NumberOfAnswers");
            DropColumn("dbo.Questions", "AnswerOption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerOption", c => c.String());
            AddColumn("dbo.Questions", "NumberOfAnswers", c => c.Int(nullable: false));
        }
    }
}
