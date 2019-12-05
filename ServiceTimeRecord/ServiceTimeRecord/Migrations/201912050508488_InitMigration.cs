namespace ServiceTimeRecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hours = c.Int(nullable: false),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Times", new[] { "Task_Id" });
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropTable("dbo.Times");
            DropTable("dbo.Tasks");
            DropTable("dbo.Employees");
        }
    }
}
