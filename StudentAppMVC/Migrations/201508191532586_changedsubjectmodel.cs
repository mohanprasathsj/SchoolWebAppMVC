namespace StudentAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedsubjectmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "ParentSubject_ParentSubjectId", "dbo.ParentSubjects");
            DropForeignKey("dbo.Subjects", "Class_SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Subjects", new[] { "Class_SchoolClassId" });
            DropIndex("dbo.Subjects", new[] { "ParentSubject_ParentSubjectId" });
            RenameColumn(table: "dbo.Subjects", name: "Class_SchoolClassId", newName: "ClassId");
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "ParentEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "ClassId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Subjects", "ClassId");
            AddForeignKey("dbo.Subjects", "ClassId", "dbo.SchoolClasses", "SchoolClassId", cascadeDelete: true);
            DropColumn("dbo.Subjects", "ParentSubject_ParentSubjectId");
            DropTable("dbo.ParentSubjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParentSubjects",
                c => new
                    {
                        ParentSubjectId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ParentSubjectId);
            
            AddColumn("dbo.Subjects", "ParentSubject_ParentSubjectId", c => c.Guid());
            DropForeignKey("dbo.Subjects", "ClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Subjects", new[] { "ClassId" });
            AlterColumn("dbo.Subjects", "ClassId", c => c.Guid());
            AlterColumn("dbo.Students", "ParentEmail", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            RenameColumn(table: "dbo.Subjects", name: "ClassId", newName: "Class_SchoolClassId");
            CreateIndex("dbo.Subjects", "ParentSubject_ParentSubjectId");
            CreateIndex("dbo.Subjects", "Class_SchoolClassId");
            AddForeignKey("dbo.Subjects", "Class_SchoolClassId", "dbo.SchoolClasses", "SchoolClassId");
            AddForeignKey("dbo.Subjects", "ParentSubject_ParentSubjectId", "dbo.ParentSubjects", "ParentSubjectId");
        }
    }
}
