namespace BBP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateqrqid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionResults", "QuestionId", "dbo.Examinations");
            DropIndex("dbo.QuestionResults", new[] { "Question_ID" });
            DropColumn("dbo.QuestionResults", "QuestionId");
            RenameColumn(table: "dbo.QuestionResults", name: "Question_ID", newName: "QuestionId");
            AddColumn("dbo.QuestionResults", "ExaminationId", c => c.Int());
            CreateIndex("dbo.QuestionResults", "ExaminationId");
            AddForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations");
            DropIndex("dbo.QuestionResults", new[] { "ExaminationId" });
            DropColumn("dbo.QuestionResults", "ExaminationId");
            RenameColumn(table: "dbo.QuestionResults", name: "QuestionId", newName: "Question_ID");
            AddColumn("dbo.QuestionResults", "QuestionId", c => c.Int());
            CreateIndex("dbo.QuestionResults", "Question_ID");
            AddForeignKey("dbo.QuestionResults", "QuestionId", "dbo.Examinations", "ID");
        }
    }
}
