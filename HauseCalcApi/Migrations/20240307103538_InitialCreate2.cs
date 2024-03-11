using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HauseCalcApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetServiceClients_SetUserContacts_UserContactsId",
                table: "SetServiceClients");

            migrationBuilder.DropIndex(
                name: "IX_SetServiceClients_UserContactsId",
                table: "SetServiceClients");

            migrationBuilder.DropColumn(
                name: "UserContactsId",
                table: "SetServiceClients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserContactsId",
                table: "SetServiceClients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SetServiceClients_UserContactsId",
                table: "SetServiceClients",
                column: "UserContactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetServiceClients_SetUserContacts_UserContactsId",
                table: "SetServiceClients",
                column: "UserContactsId",
                principalTable: "SetUserContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
