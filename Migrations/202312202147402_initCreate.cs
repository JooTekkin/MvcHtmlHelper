namespace MvcHtmlHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Dept_Id = c.Int(nullable: false, identity: true),
                        Dept_Name = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Dept_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false, maxLength: 10),
                        Lname = c.String(nullable: false, maxLength: 10),
                        Pwd = c.String(nullable: false),
                        Bod = c.DateTime(nullable: false, storeType: "date"),
                        Boh = c.DateTime(nullable: false, storeType: "date"),
                        Url = c.String(),
                        Email = c.String(),
                        Dept_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.Dept_Id, cascadeDelete: true)
                .Index(t => t.Dept_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Dept_Id", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Dept_Id" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
