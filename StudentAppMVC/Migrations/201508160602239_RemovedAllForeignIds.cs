namespace StudentAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAllForeignIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Stanadards");
            DropForeignKey("dbo.Scores", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Scores", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Scores", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.SchoolClasses", new[] { "StandardId" });
            DropIndex("dbo.Scores", new[] { "SubjectId" });
            DropIndex("dbo.Scores", new[] { "StudentId" });
            DropIndex("dbo.Scores", new[] { "ExamId" });
            RenameColumn(table: "dbo.SchoolClasses", name: "StandardId", newName: "Standard_StandardId");
            RenameColumn(table: "dbo.Scores", name: "ExamId", newName: "Exam_ExamId");
            RenameColumn(table: "dbo.Scores", name: "StudentId", newName: "Student_StudentId");
            RenameColumn(table: "dbo.Scores", name: "SubjectId", newName: "Subject_SubjectId");
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "dbo.ParentSubjects",
                c => new
                    {
                        ParentSubjectId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ParentSubjectId);
            
            AddColumn("dbo.Subjects", "ParentSubject_ParentSubjectId", c => c.Guid());
            AlterColumn("dbo.SchoolClasses", "Standard_StandardId", c => c.Guid());
            AlterColumn("dbo.Scores", "Subject_SubjectId", c => c.Guid());
            AlterColumn("dbo.Scores", "Student_StudentId", c => c.Guid());
            AlterColumn("dbo.Scores", "Exam_ExamId", c => c.Guid());
            CreateIndex("dbo.SchoolClasses", "Standard_StandardId");
            CreateIndex("dbo.Subjects", "ParentSubject_ParentSubjectId");
            CreateIndex("dbo.Scores", "Exam_ExamId");
            CreateIndex("dbo.Scores", "Student_StudentId");
            CreateIndex("dbo.Scores", "Subject_SubjectId");
            AddForeignKey("dbo.Subjects", "ParentSubject_ParentSubjectId", "dbo.ParentSubjects", "ParentSubjectId");
            AddForeignKey("dbo.SchoolClasses", "Standard_StandardId", "dbo.Standards", "StandardId");
            AddForeignKey("dbo.Scores", "Exam_ExamId", "dbo.Exams", "ExamId");
            AddForeignKey("dbo.Scores", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Scores", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
            DropColumn("dbo.Students", "ClassId");
            DropColumn("dbo.Subjects", "ParentSubjectId");
            DropColumn("dbo.Subjects", "ClassId");
            DropTable("dbo.Stanadards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stanadards",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Subjects", "ClassId", c => c.Guid(nullable: false));
            AddColumn("dbo.Subjects", "ParentSubjectId", c => c.Guid(nullable: false));
            AddColumn("dbo.Students", "ClassId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Scores", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Scores", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Scores", "Exam_ExamId", "dbo.Exams");
            DropForeignKey("dbo.SchoolClasses", "Standard_StandardId", "dbo.Standards");
            DropForeignKey("dbo.Subjects", "ParentSubject_ParentSubjectId", "dbo.ParentSubjects");
            DropIndex("dbo.Scores", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Scores", new[] { "Student_StudentId" });
            DropIndex("dbo.Scores", new[] { "Exam_ExamId" });
            DropIndex("dbo.Subjects", new[] { "ParentSubject_ParentSubjectId" });
            DropIndex("dbo.SchoolClasses", new[] { "Standard_StandardId" });
            AlterColumn("dbo.Scores", "Exam_ExamId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Scores", "Student_StudentId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Scores", "Subject_SubjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.SchoolClasses", "Standard_StandardId", c => c.Guid(nullable: false));
            DropColumn("dbo.Subjects", "ParentSubject_ParentSubjectId");
            DropTable("dbo.ParentSubjects");
            DropTable("dbo.Standards");
            RenameColumn(table: "dbo.Scores", name: "Subject_SubjectId", newName: "SubjectId");
            RenameColumn(table: "dbo.Scores", name: "Student_StudentId", newName: "StudentId");
            RenameColumn(table: "dbo.Scores", name: "Exam_ExamId", newName: "ExamId");
            RenameColumn(table: "dbo.SchoolClasses", name: "Standard_StandardId", newName: "StandardId");
            CreateIndex("dbo.Scores", "ExamId");
            CreateIndex("dbo.Scores", "StudentId");
            CreateIndex("dbo.Scores", "SubjectId");
            CreateIndex("dbo.SchoolClasses", "StandardId");
            AddForeignKey("dbo.Scores", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: true);
            AddForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Stanadards", "id", cascadeDelete: true);
        }
    }
}
