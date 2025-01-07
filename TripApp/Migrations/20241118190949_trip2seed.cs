using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anetia_TripApp.Migrations
{
    /// <inheritdoc />
    public partial class trip2seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "AccommodationId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "Luxury Hotel Paris", null },
                    { 2, null, "Paris Central Inn", null },
                    { 3, null, "Manhattan Suites", null },
                    { 4, null, "Broadway Grand Hotel", null },
                    { 5, null, "Shibuya Luxury Hotel", null },
                    { 6, null, "Tokyo Bay Hotel", null }
                });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "Name",
                value: "Eiffel Tower Tour");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "Name",
                value: "Louvre Museum Visit");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3,
                column: "Name",
                value: "Seine River Cruise");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 4,
                column: "Name",
                value: "Notre-Dame Cathedral Tour");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 5,
                column: "Name",
                value: "Statue of Liberty Tour");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 6, "Times Square Visit" },
                    { 7, "Central Park Walk" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "Name",
                value: "Hiking");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "Name",
                value: "Sightseeing");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3,
                column: "Name",
                value: "Swimming");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 4,
                column: "Name",
                value: "Shopping");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 5,
                column: "Name",
                value: "Cultural Tour");
        }
    }
}
