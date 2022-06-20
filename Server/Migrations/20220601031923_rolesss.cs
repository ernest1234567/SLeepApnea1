using Microsoft.EntityFrameworkCore.Migrations;

namespace SLeepApnea.Server.Migrations
{
    public partial class rolesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesID",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesID",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RolesID",
                table: "Patients",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RolesID",
                table: "Doctors",
                column: "RolesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Roless_RolesID",
                table: "Doctors",
                column: "RolesID",
                principalTable: "Roless",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Roless_RolesID",
                table: "Patients",
                column: "RolesID",
                principalTable: "Roless",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Roless_RolesID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Roless_RolesID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RolesID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RolesID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RolesID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RolesID",
                table: "Doctors");
        }
    }
}
