namespace SurvApe2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answerRemoveResponse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Response_Id", "dbo.Responses");
            DropIndex("dbo.Answers", new[] { "Response_Id" });
            RenameColumn(table: "dbo.Answers", name: "Response_Id", newName: "ResponseId");
            AddColumn("dbo.Responses", "Value", c => c.String());
            AlterColumn("dbo.Answers", "ResponseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "ResponseId");
            AddForeignKey("dbo.Answers", "ResponseId", "dbo.Responses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "ResponseId", "dbo.Responses");
            DropIndex("dbo.Answers", new[] { "ResponseId" });
            AlterColumn("dbo.Answers", "ResponseId", c => c.Int());
            DropColumn("dbo.Responses", "Value");
            RenameColumn(table: "dbo.Answers", name: "ResponseId", newName: "Response_Id");
            CreateIndex("dbo.Answers", "Response_Id");
            AddForeignKey("dbo.Answers", "Response_Id", "dbo.Responses", "Id");
        }
    }
}
