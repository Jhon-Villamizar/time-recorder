namespace ServiceTimeRecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTaskId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Times", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Times", new[] { "Task_Id" });
            RenameColumn(table: "dbo.Times", name: "Task_Id", newName: "TaskId");
            AlterColumn("dbo.Times", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Times", "TaskId");
            AddForeignKey("dbo.Times", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Times", new[] { "TaskId" });
            AlterColumn("dbo.Times", "TaskId", c => c.Int());
            RenameColumn(table: "dbo.Times", name: "TaskId", newName: "Task_Id");
            CreateIndex("dbo.Times", "Task_Id");
            AddForeignKey("dbo.Times", "Task_Id", "dbo.Tasks", "Id");
        }
    }
}
