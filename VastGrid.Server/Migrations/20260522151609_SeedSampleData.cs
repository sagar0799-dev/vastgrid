using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VastGrid.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Builders",
                columns: new[] { "Id", "CompanyName", "ContactEmail" },
                values: new object[,]
                {
                    { 1, "Aura Properties", "contact@auraproperties.com" },
                    { 2, "Skyline Dev", "hello@skylinedev.com" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { 1, "Alice", "alice-manager-uuid", "Johnson" });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[,]
                {
                    { 1, "Block A", 1, true, "101" },
                    { 2, "Block B", 1, false, "205" },
                    { 3, "Tower C", 2, true, "Penthouse 1" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "John", "john-sso-uuid", "Doe" },
                    { 2, 3, "Jane", "jane-sso-uuid", "Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
