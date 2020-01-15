namespace SaveTime.DaraAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        StartWork = c.DateTime(nullable: false),
                        EndWork = c.DateTime(nullable: false),
                        StepWork = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account_Id = c.Int(),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Employers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Clients", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Services", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Employees", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Branches", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Records", new[] { "Employee_Id" });
            DropIndex("dbo.Records", new[] { "Client_Id" });
            DropIndex("dbo.Employers", new[] { "Account_Id" });
            DropIndex("dbo.Clients", new[] { "Account_Id" });
            DropIndex("dbo.Services", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "Branch_Id" });
            DropIndex("dbo.Employees", new[] { "Account_Id" });
            DropIndex("dbo.Branches", new[] { "Company_Id" });
            DropTable("dbo.Records");
            DropTable("dbo.Employers");
            DropTable("dbo.Clients");
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
            DropTable("dbo.Branches");
            DropTable("dbo.Accounts");
        }
    }
}
