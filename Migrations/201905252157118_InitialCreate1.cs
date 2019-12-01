namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "type", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "caloriesBurnt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "caloriesBurnt", c => c.String());
            AlterColumn("dbo.Workouts", "type", c => c.String());
            AlterColumn("dbo.Users", "password", c => c.String());
        }
    }
}
