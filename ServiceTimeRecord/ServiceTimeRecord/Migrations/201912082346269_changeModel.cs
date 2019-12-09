namespace ServiceTimeRecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropIndex("dbo.Times", new[] { "TaskId" });
            CreateIndex("dbo.Tasks", "employeeId");
            CreateIndex("dbo.Times", "taskId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Times", new[] { "taskId" });
            DropIndex("dbo.Tasks", new[] { "employeeId" });
            CreateIndex("dbo.Times", "TaskId");
            CreateIndex("dbo.Tasks", "EmployeeId");
        }
    }
}
