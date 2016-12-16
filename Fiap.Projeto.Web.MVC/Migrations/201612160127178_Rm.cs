namespace Fiap.Projeto.Web.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Rm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rm");
        }
    }
}
