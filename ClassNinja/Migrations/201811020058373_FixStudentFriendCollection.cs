namespace ClassNinja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStudentFriendCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Private", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Student_Id", c => c.Int());
            CreateIndex("dbo.Students", "Student_Id");
            AddForeignKey("dbo.Students", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Student_Id", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Student_Id" });
            DropColumn("dbo.Students", "Student_Id");
            DropColumn("dbo.Students", "Private");
        }
    }
}
