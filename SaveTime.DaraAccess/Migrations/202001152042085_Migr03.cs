namespace SaveTime.DaraAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Employees", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Employees", new[] { "Account_Id" });
            DropIndex("dbo.Employees", new[] { "Branch_Id" });
            RenameColumn(table: "dbo.Employees", name: "Branch_Id", newName: "BranchId");
            RenameColumn(table: "dbo.Employees", name: "Account_Id", newName: "AccountId");
            AlterColumn("dbo.Employees", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "AccountId");
            CreateIndex("dbo.Employees", "BranchId");
            AddForeignKey("dbo.Employees", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "AccountId" });
            AlterColumn("dbo.Employees", "BranchId", c => c.Int());
            AlterColumn("dbo.Employees", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "AccountId", newName: "Account_Id");
            RenameColumn(table: "dbo.Employees", name: "BranchId", newName: "Branch_Id");
            CreateIndex("dbo.Employees", "Branch_Id");
            CreateIndex("dbo.Employees", "Account_Id");
            AddForeignKey("dbo.Employees", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Employees", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
