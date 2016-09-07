namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answeroptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "NumberOfAnswers", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "AnswerOption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "AnswerOption");
            DropColumn("dbo.Questions", "NumberOfAnswers");
        }
    }
}
