using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class myAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "AspNetUsers");
        }
    }
}
