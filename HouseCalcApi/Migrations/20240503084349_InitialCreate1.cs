using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseCalcApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientRequestIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactID = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequestIds", x => x.Id);
                });

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
                name: "UserCalculationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    table.PrimaryKey("PK_UserCalculationRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameUser = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneUser = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRequestIds");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "UserCalculationRequests");

            migrationBuilder.DropTable(
                name: "UserContacts");
        }
    }
}
