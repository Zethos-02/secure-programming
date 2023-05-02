using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace secure_programming.Data.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirportDestination",
                table: "Airplane",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirportOrigin",
                table: "Airplane",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "Airplane",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportDestination",
                table: "Airplane");

            migrationBuilder.DropColumn(
                name: "AirportOrigin",
                table: "Airplane");

            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "Airplane");
        }
    }
}
