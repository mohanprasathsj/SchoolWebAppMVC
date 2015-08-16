namespace StudentAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Class_SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Students", new[] { "Class_SchoolClassId" });
            RenameColumn(table: "dbo.Students", name: "Class_SchoolClassId", newName: "StudentClassId");
            AlterColumn("dbo.Students", "StudentClassId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Students", "StudentClassId");
            AddForeignKey("dbo.Students", "StudentClassId", "dbo.SchoolClasses", "SchoolClassId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Students", new[] { "StudentClassId" });
            AlterColumn("dbo.Students", "StudentClassId", c => c.Guid());
            RenameColumn(table: "dbo.Students", name: "StudentClassId", newName: "Class_SchoolClassId");
            CreateIndex("dbo.Students", "Class_SchoolClassId");
            AddForeignKey("dbo.Students", "Class_SchoolClassId", "dbo.SchoolClasses", "SchoolClassId");
        }
    }
}
