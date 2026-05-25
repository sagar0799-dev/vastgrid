using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VastGrid.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedBulkData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentManagers",
                keyColumns: new[] { "ApartmentsId", "ManagersId" },
                keyValues: new object[] { 2, 1 });

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
                columns: new[] { "BlockName", "BuilderId", "UnitNumber" },
                values: new object[] { "Block A", 1, "303" });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[,]
                {
                    { 4, "Block A", 1, true, "404" },
                    { 5, "Block A", 1, true, "505" },
                    { 6, "Block A", 1, true, "606" },
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
                    { 30, "Block B", 2, true, "15015" }
                });

            migrationBuilder.InsertData(
                table: "Builders",
                columns: new[] { "Id", "CompanyName", "ContactEmail" },
                values: new object[] { 3, "Pinnacle Real Estate", "info@pinnacle.com" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { "Manager1First", "manager-1-sso-uuid", "Manager1Last" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 2, "Manager2First", "manager-2-sso-uuid", "Manager2Last" },
                    { 3, "Manager3First", "manager-3-sso-uuid", "Manager3Last" },
                    { 4, "Manager4First", "manager-4-sso-uuid", "Manager4Last" },
                    { 5, "Manager5First", "manager-5-sso-uuid", "Manager5Last" },
                    { 6, "Manager6First", "manager-6-sso-uuid", "Manager6Last" },
                    { 7, "Manager7First", "manager-7-sso-uuid", "Manager7Last" },
                    { 8, "Manager8First", "manager-8-sso-uuid", "Manager8Last" },
                    { 9, "Manager9First", "manager-9-sso-uuid", "Manager9Last" },
                    { 10, "Manager10First", "manager-10-sso-uuid", "Manager10Last" },
                    { 11, "Manager11First", "manager-11-sso-uuid", "Manager11Last" },
                    { 12, "Manager12First", "manager-12-sso-uuid", "Manager12Last" },
                    { 13, "Manager13First", "manager-13-sso-uuid", "Manager13Last" },
                    { 14, "Manager14First", "manager-14-sso-uuid", "Manager14Last" },
                    { 15, "Manager15First", "manager-15-sso-uuid", "Manager15Last" }
                });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { "Resident2First", "resident-2-sso-uuid", "Resident2Last" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { 2, "Resident3First", "resident-3-sso-uuid", "Resident3Last" });

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 3, 3, "Resident4First", "resident-4-sso-uuid", "Resident4Last" },
                    { 4, 3, "Resident5First", "resident-5-sso-uuid", "Resident5Last" }
                });

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
                    { 6, 2 },
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
                    { 30, 6 }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "BlockName", "BuilderId", "IsOccupied", "UnitNumber" },
                values: new object[,]
                {
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

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 5, 4, "Resident6First", "resident-6-sso-uuid", "Resident6Last" },
                    { 6, 5, "Resident7First", "resident-7-sso-uuid", "Resident7Last" },
                    { 7, 6, "Resident8First", "resident-8-sso-uuid", "Resident8Last" },
                    { 8, 6, "Resident9First", "resident-9-sso-uuid", "Resident9Last" },
                    { 9, 7, "Resident10First", "resident-10-sso-uuid", "Resident10Last" },
                    { 10, 8, "Resident11First", "resident-11-sso-uuid", "Resident11Last" },
                    { 11, 9, "Resident12First", "resident-12-sso-uuid", "Resident12Last" },
                    { 12, 9, "Resident13First", "resident-13-sso-uuid", "Resident13Last" },
                    { 13, 10, "Resident14First", "resident-14-sso-uuid", "Resident14Last" },
                    { 14, 11, "Resident15First", "resident-15-sso-uuid", "Resident15Last" },
                    { 15, 12, "Resident16First", "resident-16-sso-uuid", "Resident16Last" },
                    { 16, 12, "Resident17First", "resident-17-sso-uuid", "Resident17Last" },
                    { 17, 13, "Resident18First", "resident-18-sso-uuid", "Resident18Last" },
                    { 18, 14, "Resident19First", "resident-19-sso-uuid", "Resident19Last" },
                    { 19, 15, "Resident20First", "resident-20-sso-uuid", "Resident20Last" },
                    { 20, 15, "Resident21First", "resident-21-sso-uuid", "Resident21Last" },
                    { 21, 16, "Resident22First", "resident-22-sso-uuid", "Resident22Last" },
                    { 22, 17, "Resident23First", "resident-23-sso-uuid", "Resident23Last" },
                    { 23, 18, "Resident24First", "resident-24-sso-uuid", "Resident24Last" },
                    { 24, 18, "Resident25First", "resident-25-sso-uuid", "Resident25Last" },
                    { 25, 19, "Resident26First", "resident-26-sso-uuid", "Resident26Last" },
                    { 26, 20, "Resident27First", "resident-27-sso-uuid", "Resident27Last" },
                    { 27, 21, "Resident28First", "resident-28-sso-uuid", "Resident28Last" },
                    { 28, 21, "Resident29First", "resident-29-sso-uuid", "Resident29Last" },
                    { 29, 22, "Resident30First", "resident-30-sso-uuid", "Resident30Last" },
                    { 30, 23, "Resident31First", "resident-31-sso-uuid", "Resident31Last" },
                    { 31, 24, "Resident32First", "resident-32-sso-uuid", "Resident32Last" },
                    { 32, 24, "Resident33First", "resident-33-sso-uuid", "Resident33Last" },
                    { 33, 25, "Resident34First", "resident-34-sso-uuid", "Resident34Last" },
                    { 34, 26, "Resident35First", "resident-35-sso-uuid", "Resident35Last" },
                    { 35, 27, "Resident36First", "resident-36-sso-uuid", "Resident36Last" },
                    { 36, 27, "Resident37First", "resident-37-sso-uuid", "Resident37Last" },
                    { 37, 28, "Resident38First", "resident-38-sso-uuid", "Resident38Last" },
                    { 38, 29, "Resident39First", "resident-39-sso-uuid", "Resident39Last" },
                    { 39, 30, "Resident40First", "resident-40-sso-uuid", "Resident40Last" },
                    { 40, 30, "Resident41First", "resident-41-sso-uuid", "Resident41Last" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
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

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[,]
                {
                    { 41, 31, "Resident42First", "resident-42-sso-uuid", "Resident42Last" },
                    { 42, 32, "Resident43First", "resident-43-sso-uuid", "Resident43Last" },
                    { 43, 33, "Resident44First", "resident-44-sso-uuid", "Resident44Last" },
                    { 44, 33, "Resident45First", "resident-45-sso-uuid", "Resident45Last" },
                    { 45, 34, "Resident46First", "resident-46-sso-uuid", "Resident46Last" },
                    { 46, 35, "Resident47First", "resident-47-sso-uuid", "Resident47Last" },
                    { 47, 36, "Resident48First", "resident-48-sso-uuid", "Resident48Last" },
                    { 48, 36, "Resident49First", "resident-49-sso-uuid", "Resident49Last" },
                    { 49, 37, "Resident50First", "resident-50-sso-uuid", "Resident50Last" },
                    { 50, 38, "Resident51First", "resident-51-sso-uuid", "Resident51Last" },
                    { 51, 39, "Resident52First", "resident-52-sso-uuid", "Resident52Last" },
                    { 52, 39, "Resident53First", "resident-53-sso-uuid", "Resident53Last" },
                    { 53, 40, "Resident54First", "resident-54-sso-uuid", "Resident54Last" },
                    { 54, 41, "Resident55First", "resident-55-sso-uuid", "Resident55Last" },
                    { 55, 42, "Resident56First", "resident-56-sso-uuid", "Resident56Last" },
                    { 56, 42, "Resident57First", "resident-57-sso-uuid", "Resident57Last" },
                    { 57, 43, "Resident58First", "resident-58-sso-uuid", "Resident58Last" },
                    { 58, 44, "Resident59First", "resident-59-sso-uuid", "Resident59Last" },
                    { 59, 45, "Resident60First", "resident-60-sso-uuid", "Resident60Last" },
                    { 60, 45, "Resident61First", "resident-61-sso-uuid", "Resident61Last" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 6);

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

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "ApartmentManagers",
                columns: new[] { "ApartmentsId", "ManagersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BlockName", "IsOccupied", "UnitNumber" },
                values: new object[] { "Block B", false, "205" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BlockName", "BuilderId", "UnitNumber" },
                values: new object[] { "Tower C", 2, "Penthouse 1" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { "Alice", "alice-manager-uuid", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { "John", "john-sso-uuid", "Doe" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApartmentId", "FirstName", "KeycloakUserId", "LastName" },
                values: new object[] { 3, "Jane", "jane-sso-uuid", "Smith" });
        }
    }
}
