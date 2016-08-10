namespace BBP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        context = c.String(),
                        Created = c.DateTime(),
                        ExamId = c.Int(),
                        ExamQuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Examinations", t => t.ExamId)
                .ForeignKey("dbo.ExamQuestions", t => t.ExamQuestionId)
                .Index(t => t.ExamId)
                .Index(t => t.ExamQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "ExamQuestionId", "dbo.ExamQuestions");
            DropForeignKey("dbo.Feedbacks", "ExamId", "dbo.Examinations");
            DropIndex("dbo.Feedbacks", new[] { "ExamQuestionId" });
            DropIndex("dbo.Feedbacks", new[] { "ExamId" });
            DropTable("dbo.Feedbacks");
        }
    }
}
