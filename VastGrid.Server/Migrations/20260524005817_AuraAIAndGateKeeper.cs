using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VastGrid.Server.Migrations
{
    /// <inheritdoc />
    public partial class AuraAIAndGateKeeper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DiagnosisResult",
                table: "Tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Residents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeycloakUserId",
                table: "Builders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitorName = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ResidentId = table.Column<int>(type: "integer", nullable: false),
                    WatchmanId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorLogs_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContactEmail", "KeycloakUserId" },
                values: new object[] { "builder@vastgrid.local", "dev-builder-sub" });

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContactEmail", "KeycloakUserId" },
                values: new object[] { "skyline@vastgrid.local", null });

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ContactEmail", "KeycloakUserId" },
                values: new object[] { "pinnacle@vastgrid.local", null });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+91 9800000002");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "+91 9800000003");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhoneNumber",
                value: "+91 9800000004");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhoneNumber",
                value: "+91 9800000005");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "+91 9800000006");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhoneNumber",
                value: "+91 9800000007");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhoneNumber",
                value: "+91 9800000008");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhoneNumber",
                value: "+91 9800000009");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhoneNumber",
                value: "+91 9800000010");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhoneNumber",
                value: "+91 9800000011");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhoneNumber",
                value: "+91 9800000012");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 12,
                column: "PhoneNumber",
                value: "+91 9800000013");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 13,
                column: "PhoneNumber",
                value: "+91 9800000014");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 14,
                column: "PhoneNumber",
                value: "+91 9800000015");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 15,
                column: "PhoneNumber",
                value: "+91 9800000016");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 16,
                column: "PhoneNumber",
                value: "+91 9800000017");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 17,
                column: "PhoneNumber",
                value: "+91 9800000018");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 18,
                column: "PhoneNumber",
                value: "+91 9800000019");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 19,
                column: "PhoneNumber",
                value: "+91 9800000020");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 20,
                column: "PhoneNumber",
                value: "+91 9800000021");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 21,
                column: "PhoneNumber",
                value: "+91 9800000022");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 22,
                column: "PhoneNumber",
                value: "+91 9800000023");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 23,
                column: "PhoneNumber",
                value: "+91 9800000024");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 24,
                column: "PhoneNumber",
                value: "+91 9800000025");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 25,
                column: "PhoneNumber",
                value: "+91 9800000026");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 26,
                column: "PhoneNumber",
                value: "+91 9800000027");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 27,
                column: "PhoneNumber",
                value: "+91 9800000028");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 28,
                column: "PhoneNumber",
                value: "+91 9800000029");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 29,
                column: "PhoneNumber",
                value: "+91 9800000030");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 30,
                column: "PhoneNumber",
                value: "+91 9800000031");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 31,
                column: "PhoneNumber",
                value: "+91 9800000032");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 32,
                column: "PhoneNumber",
                value: "+91 9800000033");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 33,
                column: "PhoneNumber",
                value: "+91 9800000034");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 34,
                column: "PhoneNumber",
                value: "+91 9800000035");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 35,
                column: "PhoneNumber",
                value: "+91 9800000036");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 36,
                column: "PhoneNumber",
                value: "+91 9800000037");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 37,
                column: "PhoneNumber",
                value: "+91 9800000038");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 38,
                column: "PhoneNumber",
                value: "+91 9800000039");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 39,
                column: "PhoneNumber",
                value: "+91 9800000040");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 40,
                column: "PhoneNumber",
                value: "+91 9800000041");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 41,
                column: "PhoneNumber",
                value: "+91 9800000042");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 42,
                column: "PhoneNumber",
                value: "+91 9800000043");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 43,
                column: "PhoneNumber",
                value: "+91 9800000044");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 44,
                column: "PhoneNumber",
                value: "+91 9800000045");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 45,
                column: "PhoneNumber",
                value: "+91 9800000046");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 46,
                column: "PhoneNumber",
                value: "+91 9800000047");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 47,
                column: "PhoneNumber",
                value: "+91 9800000048");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 48,
                column: "PhoneNumber",
                value: "+91 9800000049");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 49,
                column: "PhoneNumber",
                value: "+91 9800000050");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 50,
                column: "PhoneNumber",
                value: "+91 9800000051");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 51,
                column: "PhoneNumber",
                value: "+91 9800000052");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 52,
                column: "PhoneNumber",
                value: "+91 9800000053");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 53,
                column: "PhoneNumber",
                value: "+91 9800000054");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 54,
                column: "PhoneNumber",
                value: "+91 9800000055");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 55,
                column: "PhoneNumber",
                value: "+91 9800000056");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 56,
                column: "PhoneNumber",
                value: "+91 9800000057");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 57,
                column: "PhoneNumber",
                value: "+91 9800000058");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 58,
                column: "PhoneNumber",
                value: "+91 9800000059");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 59,
                column: "PhoneNumber",
                value: "+91 9800000060");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 60,
                column: "PhoneNumber",
                value: "+91 9800000061");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 61,
                column: "PhoneNumber",
                value: "+91 9800000062");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 62,
                column: "PhoneNumber",
                value: "+91 9800000063");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 63,
                column: "PhoneNumber",
                value: "+91 9800000064");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 64,
                column: "PhoneNumber",
                value: "+91 9800000065");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 65,
                column: "PhoneNumber",
                value: "+91 9800000066");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 66,
                column: "PhoneNumber",
                value: "+91 9800000067");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 67,
                column: "PhoneNumber",
                value: "+91 9800000068");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 68,
                column: "PhoneNumber",
                value: "+91 9800000069");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 69,
                column: "PhoneNumber",
                value: "+91 9800000070");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 70,
                column: "PhoneNumber",
                value: "+91 9800000071");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 71,
                column: "PhoneNumber",
                value: "+91 9800000072");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 72,
                column: "PhoneNumber",
                value: "+91 9800000073");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApartmentId",
                table: "Tickets",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ResidentId",
                table: "Tickets",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLogs_ResidentId",
                table: "VisitorLogs",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Apartments_ApartmentId",
                table: "Tickets",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Residents_ResidentId",
                table: "Tickets",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Apartments_ApartmentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Residents_ResidentId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "VisitorLogs");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ApartmentId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ResidentId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DiagnosisResult",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "KeycloakUserId",
                table: "Builders");

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactEmail",
                value: "contact@auraproperties.com");

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContactEmail",
                value: "hello@skylinedev.com");

            migrationBuilder.UpdateData(
                table: "Builders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ContactEmail",
                value: "info@pinnacle.com");
        }
    }
}
