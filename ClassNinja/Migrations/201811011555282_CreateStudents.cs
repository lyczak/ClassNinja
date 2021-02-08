namespace ClassNinja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EspUsername", c => c.String());
            DropColumn("dbo.Students", "FirstName");
            DropColumn("dbo.Students", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "FirstName", c => c.String());
            DropColumn("dbo.Students", "EspUsername");
        }
    }
}
