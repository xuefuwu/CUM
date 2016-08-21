namespace BBP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExaminationIdcase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations");
            AddForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations");
            AddForeignKey("dbo.QuestionResults", "ExaminationId", "dbo.Examinations", "ID");
        }
    }
}
