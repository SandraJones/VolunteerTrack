namespace VolunteerTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUsersToActivities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VolunteerActivities", "VolunteerUser_VolunteerUserId", c => c.Int());
            CreateIndex("dbo.VolunteerActivities", "VolunteerUser_VolunteerUserId");
            AddForeignKey("dbo.VolunteerActivities", "VolunteerUser_VolunteerUserId", "dbo.VolunteerUsers", "VolunteerUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolunteerActivities", "VolunteerUser_VolunteerUserId", "dbo.VolunteerUsers");
            DropIndex("dbo.VolunteerActivities", new[] { "VolunteerUser_VolunteerUserId" });
            DropColumn("dbo.VolunteerActivities", "VolunteerUser_VolunteerUserId");
        }
    }
}
