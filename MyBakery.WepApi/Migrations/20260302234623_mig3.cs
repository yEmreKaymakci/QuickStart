using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBakery.WepApi.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestimonialId",
                table: "Testimonials",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Testimonials",
                newName: "TestimonialId");
        }
    }
}
