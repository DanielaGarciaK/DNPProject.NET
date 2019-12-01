namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        duration = c.Time(nullable: false, precision: 7),
                        caloriesBurnt = c.String(),
                        startTime = c.DateTime(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workouts");
            DropTable("dbo.Users");
        }
    }
}
