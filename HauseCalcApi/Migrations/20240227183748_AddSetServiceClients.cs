﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HauseCalcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSetServiceClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetServiceClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    areaHouseSquarMeters = table.Column<int>(type: "INTEGER", nullable: false),
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
                    AllCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetServiceClients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetServiceClients");
        }
    }
}
