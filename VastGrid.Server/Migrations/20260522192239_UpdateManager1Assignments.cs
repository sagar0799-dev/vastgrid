using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VastGrid.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManager1Assignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 4 }
                });
        }
    }
}
