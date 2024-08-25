using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaulterClients.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class adjust_on_relationship_client_and_billing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Clients_Id",
                table: "Billings");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_ClientId",
                table: "Billings",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Clients_ClientId",
                table: "Billings",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Clients_ClientId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_ClientId",
                table: "Billings");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Clients_Id",
                table: "Billings",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
