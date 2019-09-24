using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoVet.Migrations
{
    public partial class vet5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clients_ClientId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Patients",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ClientId",
                table: "Patients",
                newName: "IX_Patients_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clients_OwnerId",
                table: "Patients",
                column: "OwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clients_OwnerId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Patients",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_OwnerId",
                table: "Patients",
                newName: "IX_Patients_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clients_ClientId",
                table: "Patients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
