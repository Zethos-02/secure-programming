using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace secure_programming.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    AirplaneID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxSeat = table.Column<int>(type: "int", nullable: false),
                    FlightID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assigned = table.Column<string>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.AirplaneID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplane");
        }
    }
}
