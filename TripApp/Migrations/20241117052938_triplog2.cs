using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anetia_TripApp.Migrations
{
    /// <inheritdoc />
    public partial class triplog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationEmail",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationPhone",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingsToDo1",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingsToDo2",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingsToDo3",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTrip",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    TripsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTrip", x => new { x.ActivitiesActivityId, x.TripsTripId });
                    table.ForeignKey(
                        name: "FK_ActivityTrip_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityTrip_Trips_TripsTripId",
                        column: x => x.TripsTripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 1, "Hiking" },
                    { 2, "Sightseeing" },
                    { 3, "Swimming" },
                    { 4, "Shopping" },
                    { 5, "Cultural Tour" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "Name" },
                values: new object[,]
                {
                    { 1, "Paris" },
                    { 2, "New York" },
                    { 3, "Tokyo" },
                    { 4, "Dubai" },
                    { 5, "Singapore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AccommodationId",
                table: "Trips",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTrip_TripsTripId",
                table: "ActivityTrip",
                column: "TripsTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Accommodations_AccommodationId",
                table: "Trips",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "AccommodationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Destinations_DestinationId",
                table: "Trips",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Accommodations_AccommodationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Destinations_DestinationId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "ActivityTrip");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AccommodationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Trips");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationEmail",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationPhone",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThingsToDo1",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingsToDo2",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingsToDo3",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
