using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBakery.WepApi.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Features");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
