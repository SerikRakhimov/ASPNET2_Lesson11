namespace SaveTime.DaraAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Branches", new[] { "Company_Id" });
            RenameColumn(table: "dbo.Branches", name: "Company_Id", newName: "CompanyId");
            AlterColumn("dbo.Branches", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "CompanyId");
            AddForeignKey("dbo.Branches", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Branches", new[] { "CompanyId" });
            AlterColumn("dbo.Branches", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Branches", name: "CompanyId", newName: "Company_Id");
            CreateIndex("dbo.Branches", "Company_Id");
            AddForeignKey("dbo.Branches", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
