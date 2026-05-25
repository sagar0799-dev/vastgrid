using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VastGrid.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalFlatsToApartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 16, 8 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 17, 8 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 20, 6 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 20, 7 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 21, 7 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 22, 8 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 23, 9 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 24, 10 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 24, 11 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 25, 6 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 26, 7 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 27, 8 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 28, 9 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 28, 10 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 29, 10 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 30, 6 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 31, 12 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 32, 13 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 32, 14 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 33, 14 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 34, 15 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 35, 11 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 36, 12 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 36, 13 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 37, 13 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 38, 14 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 39, 15 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 40, 11 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 40, 12 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 41, 12 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 42, 13 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 43, 14 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 44, 15 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 45, 11 });

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "TotalFlats",
                table: "Apartments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 1, 12 },
                    { 2, 1 },
                    { 2, 7 },
                    { 2, 13 },
                    { 3, 2 },
                    { 3, 8 },
                    { 3, 14 },
                    { 4, 3 },
                    { 4, 9 },
                    { 4, 15 },
                    { 5, 3 },
                    { 5, 10 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 11 }
                });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalFlats",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BlockName", "TotalFlats" },
                values: new object[] { "Block B", 50 });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BlockName", "BuilderId", "TotalFlats" },
                values: new object[] { "Block C", 2, 50 });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BlockName", "BuilderId", "TotalFlats" },
                values: new object[] { "Block D", 2, 50 });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BlockName", "BuilderId", "TotalFlats" },
                values: new object[] { "Block E", 3, 50 });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BlockName", "BuilderId", "TotalFlats" },
                values: new object[] { "Block F", 3, 50 });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 16,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 17,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 19,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 20,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 21,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 22,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 23,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 24,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 25,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 26,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 27,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 28,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 29,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 30,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 31,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 32,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 33,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 34,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 35,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 36,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 37,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 38,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 39,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 40,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 41,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 42,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 43,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 44,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 45,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 46,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 47,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 48,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 49,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 50,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 51,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 52,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 53,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 54,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 55,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 56,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 57,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 58,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 59,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 60,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 61, 6, "Resident62First", "resident-62-sso-uuid", "Resident62Last" },
                    { 62, 6, "Resident63First", "resident-63-sso-uuid", "Resident63Last" },
                    { 63, 6, "Resident64First", "resident-64-sso-uuid", "Resident64Last" },
                    { 64, 6, "Resident65First", "resident-65-sso-uuid", "Resident65Last" },
                    { 65, 6, "Resident66First", "resident-66-sso-uuid", "Resident66Last" },
                    { 66, 6, "Resident67First", "resident-67-sso-uuid", "Resident67Last" },
                    { 67, 6, "Resident68First", "resident-68-sso-uuid", "Resident68Last" },
                    { 68, 6, "Resident69First", "resident-69-sso-uuid", "Resident69Last" },
                    { 69, 6, "Resident70First", "resident-70-sso-uuid", "Resident70Last" },
                    { 70, 6, "Resident71First", "resident-71-sso-uuid", "Resident71Last" },
                    { 71, 6, "Resident72First", "resident-72-sso-uuid", "Resident72Last" },
                    { 72, 6, "Resident73First", "resident-73-sso-uuid", "Resident73Last" }
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
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DropColumn(
                name: "TotalFlats",
                table: "Apartments");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Apartments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Apartments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 1 },
                    { 6, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsOccupied", "UnitNumber" },
                values: new object[] { true, "101" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BlockName", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block A", true, "202" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block A", 1, true, "303" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block A", 1, true, "404" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block A", 1, true, "505" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block A", 1, true, "606" });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[,]
                {
                    { 7, "Block A", 1, true, "707" },
                    { 8, "Block A", 1, true, "808" },
                    { 9, "Block A", 1, true, "909" },
                    { 10, "Block A", 1, true, "10010" },
                    { 11, "Block A", 1, true, "11011" },
                    { 12, "Block A", 1, true, "12012" },
                    { 13, "Block A", 1, true, "13013" },
                    { 14, "Block A", 1, true, "14014" },
                    { 15, "Block A", 1, true, "15015" },
                    { 16, "Block B", 2, true, "101" },
                    { 17, "Block B", 2, true, "202" },
                    { 18, "Block B", 2, true, "303" },
                    { 19, "Block B", 2, true, "404" },
                    { 20, "Block B", 2, true, "505" },
                    { 21, "Block B", 2, true, "606" },
                    { 22, "Block B", 2, true, "707" },
                    { 23, "Block B", 2, true, "808" },
                    { 24, "Block B", 2, true, "909" },
                    { 25, "Block B", 2, true, "10010" },
                    { 26, "Block B", 2, true, "11011" },
                    { 27, "Block B", 2, true, "12012" },
                    { 28, "Block B", 2, true, "13013" },
                    { 29, "Block B", 2, true, "14014" },
                    { 30, "Block B", 2, true, "15015" },
                    { 31, "Block C", 3, true, "101" },
                    { 32, "Block C", 3, true, "202" },
                    { 33, "Block C", 3, true, "303" },
                    { 34, "Block C", 3, true, "404" },
                    { 35, "Block C", 3, true, "505" },
                    { 36, "Block C", 3, true, "606" },
                    { 37, "Block C", 3, true, "707" },
                    { 38, "Block C", 3, true, "808" },
                    { 39, "Block C", 3, true, "909" },
                    { 40, "Block C", 3, true, "10010" },
                    { 41, "Block C", 3, true, "11011" },
                    { 42, "Block C", 3, true, "12012" },
                    { 43, "Block C", 3, true, "13013" },
                    { 44, "Block C", 3, true, "14014" },
                    { 45, "Block C", 3, true, "15015" }
                });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApartmentId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApartmentId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApartmentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApartmentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApartmentId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApartmentId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApartmentId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 16,
                column: "ApartmentId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 17,
                column: "ApartmentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApartmentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 19,
                column: "ApartmentId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 20,
                column: "ApartmentId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 21,
                column: "ApartmentId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 22,
                column: "ApartmentId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 23,
                column: "ApartmentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 24,
                column: "ApartmentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 25,
                column: "ApartmentId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 26,
                column: "ApartmentId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 27,
                column: "ApartmentId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 28,
                column: "ApartmentId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 29,
                column: "ApartmentId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 30,
                column: "ApartmentId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 31,
                column: "ApartmentId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 32,
                column: "ApartmentId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 33,
                column: "ApartmentId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 34,
                column: "ApartmentId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 35,
                column: "ApartmentId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 36,
                column: "ApartmentId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 37,
                column: "ApartmentId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 38,
                column: "ApartmentId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 39,
                column: "ApartmentId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 40,
                column: "ApartmentId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 41,
                column: "ApartmentId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 42,
                column: "ApartmentId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 43,
                column: "ApartmentId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 44,
                column: "ApartmentId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 45,
                column: "ApartmentId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 46,
                column: "ApartmentId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 47,
                column: "ApartmentId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 48,
                column: "ApartmentId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 49,
                column: "ApartmentId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 50,
                column: "ApartmentId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 51,
                column: "ApartmentId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 52,
                column: "ApartmentId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 53,
                column: "ApartmentId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 54,
                column: "ApartmentId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 55,
                column: "ApartmentId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 56,
                column: "ApartmentId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 57,
                column: "ApartmentId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 58,
                column: "ApartmentId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 59,
                column: "ApartmentId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 60,
                column: "ApartmentId",
                value: 45);

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 7, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 9, 5 },
                    { 10, 1 },
                    { 11, 2 },
                    { 12, 3 },
                    { 12, 4 },
                    { 13, 4 },
                    { 14, 5 },
                    { 15, 1 },
                    { 16, 7 },
                    { 16, 8 },
                    { 17, 8 },
                    { 18, 9 },
                    { 19, 10 },
                    { 20, 6 },
                    { 20, 7 },
                    { 21, 7 },
                    { 22, 8 },
                    { 23, 9 },
                    { 24, 10 },
                    { 24, 11 },
                    { 25, 6 },
                    { 26, 7 },
                    { 27, 8 },
                    { 28, 9 },
                    { 28, 10 },
                    { 29, 10 },
                    { 30, 6 },
                    { 31, 12 },
                    { 32, 13 },
                    { 32, 14 },
                    { 33, 14 },
                    { 34, 15 },
                    { 35, 11 },
                    { 36, 12 },
                    { 36, 13 },
                    { 37, 13 },
                    { 38, 14 },
                    { 39, 15 },
                    { 40, 11 },
                    { 40, 12 },
                    { 41, 12 },
                    { 42, 13 },
                    { 43, 14 },
                    { 44, 1 },
                    { 44, 15 },
                    { 45, 11 }
                });
        }
    }
}
