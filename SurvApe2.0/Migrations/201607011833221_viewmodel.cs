namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Responses", "Question_Id", c => c.Int());
            CreateIndex("dbo.Responses", "Question_Id");
            AddForeignKey("dbo.Responses", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Responses", new[] { "Question_Id" });
            DropColumn("dbo.Responses", "Question_Id");
        }
    }
}
