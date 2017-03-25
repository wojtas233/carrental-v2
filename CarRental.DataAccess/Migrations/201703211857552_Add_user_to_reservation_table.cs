namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_user_to_reservation_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "User_Id");
            AddForeignKey("dbo.Reservations", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropColumn("dbo.Reservations", "User_Id");
        }
    }
}
