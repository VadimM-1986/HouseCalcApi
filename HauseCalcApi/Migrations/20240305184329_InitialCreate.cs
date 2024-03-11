using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HauseCalcApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetUserContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserRequestLists = table.Column<string>(type: "TEXT", nullable: false),
                    NameUser = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetUserContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetServiceClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserContactsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AreaHouseSquarMeters = table.Column<int>(type: "INTEGER", nullable: false),
                    Walls = table.Column<int>(type: "INTEGER", nullable: false),
                    Projects = table.Column<int>(type: "INTEGER", nullable: false),
                    Geology = table.Column<int>(type: "INTEGER", nullable: false),
                    Geodesy = table.Column<int>(type: "INTEGER", nullable: false),
                    Construction = table.Column<int>(type: "INTEGER", nullable: false),
                    Armo = table.Column<int>(type: "INTEGER", nullable: false),
                    Seams = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryDistanceKilometers = table.Column<int>(type: "INTEGER", nullable: false),
                    Fundation = table.Column<int>(type: "INTEGER", nullable: false),
                    Roof = table.Column<int>(type: "INTEGER", nullable: false),
                    FiledWindowArea = table.Column<int>(type: "INTEGER", nullable: false),
                    Door = table.Column<int>(type: "INTEGER", nullable: false),
                    AllCost = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetServiceClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetServiceClients_SetUserContacts_UserContactsId",
                        column: x => x.UserContactsId,
                        principalTable: "SetUserContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "setwalls", 16000 },
                    { 2, "project", 650 },
                    { 3, "geologi", 40000 },
                    { 4, "geodesy", 15000 },
                    { 5, "construction", 5500 },
                    { 6, "armo", 300 },
                    { 7, "seams", 300 },
                    { 8, "delivery", 200 },
                    { 9, "fundation", 11500 },
                    { 10, "roof", 13500 },
                    { 11, "windows", 15500 },
                    { 12, "door", 65000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetServiceClients_UserContactsId",
                table: "SetServiceClients",
                column: "UserContactsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "SetServiceClients");

            migrationBuilder.DropTable(
                name: "SetUserContacts");
        }
    }
}
