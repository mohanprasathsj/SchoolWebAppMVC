namespace StudentAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldinStandard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolClasses", "Standard_StandardId", "dbo.Standards");
            DropIndex("dbo.SchoolClasses", new[] { "Standard_StandardId" });
            RenameColumn(table: "dbo.SchoolClasses", name: "Standard_StandardId", newName: "StandardId");
            AddColumn("dbo.Standards", "Name", c => c.String());
            AlterColumn("dbo.SchoolClasses", "StandardId", c => c.Guid(nullable: false));
            CreateIndex("dbo.SchoolClasses", "StandardId");
            AddForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Standards", "StandardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolClasses", "StandardId", "dbo.Standards");
            DropIndex("dbo.SchoolClasses", new[] { "StandardId" });
            AlterColumn("dbo.SchoolClasses", "StandardId", c => c.Guid());
            DropColumn("dbo.Standards", "Name");
            RenameColumn(table: "dbo.SchoolClasses", name: "StandardId", newName: "Standard_StandardId");
            CreateIndex("dbo.SchoolClasses", "Standard_StandardId");
            AddForeignKey("dbo.SchoolClasses", "Standard_StandardId", "dbo.Standards", "StandardId");
        }
    }
}
