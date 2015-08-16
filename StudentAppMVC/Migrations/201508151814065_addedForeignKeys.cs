namespace StudentAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "SchoolClass_SchoolClassId", newName: "Class_SchoolClassId");
            RenameColumn(table: "dbo.Subjects", name: "SchoolClass_SchoolClassId", newName: "Class_SchoolClassId");
            RenameIndex(table: "dbo.Students", name: "IX_SchoolClass_SchoolClassId", newName: "IX_Class_SchoolClassId");
            RenameIndex(table: "dbo.Subjects", name: "IX_SchoolClass_SchoolClassId", newName: "IX_Class_SchoolClassId");
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
            
            CreateIndex("dbo.SchoolClasses", "StandardId");
            CreateIndex("dbo.Scores", "SubjectId");
            CreateIndex("dbo.Scores", "StudentId");
            CreateIndex("dbo.Scores", "ExamId");
            AddForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Stanadards", "id", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Scores", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Scores", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Stanadards");
            DropIndex("dbo.Scores", new[] { "ExamId" });
            DropIndex("dbo.Scores", new[] { "StudentId" });
            DropIndex("dbo.Scores", new[] { "SubjectId" });
            DropIndex("dbo.SchoolClasses", new[] { "StandardId" });
            DropTable("dbo.Stanadards");
            RenameIndex(table: "dbo.Subjects", name: "IX_Class_SchoolClassId", newName: "IX_SchoolClass_SchoolClassId");
            RenameIndex(table: "dbo.Students", name: "IX_Class_SchoolClassId", newName: "IX_SchoolClass_SchoolClassId");
            RenameColumn(table: "dbo.Subjects", name: "Class_SchoolClassId", newName: "SchoolClass_SchoolClassId");
            RenameColumn(table: "dbo.Students", name: "Class_SchoolClassId", newName: "SchoolClass_SchoolClassId");
        }
    }
}
