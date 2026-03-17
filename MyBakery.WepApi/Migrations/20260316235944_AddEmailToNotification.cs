using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBakery.WepApi.Migrations
{
    public partial class AddEmailToNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Notifications");
        }
    }
}
