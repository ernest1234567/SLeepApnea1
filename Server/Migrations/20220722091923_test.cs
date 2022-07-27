using Microsoft.EntityFrameworkCore.Migrations;

namespace SLeepApnea.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Roless_RolesID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RolesID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RolesID",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesID",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RolesID",
                table: "Patients",
                column: "RolesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Roless_RolesID",
                table: "Patients",
                column: "RolesID",
                principalTable: "Roless",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
