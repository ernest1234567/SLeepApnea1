using Microsoft.EntityFrameworkCore.Migrations;

namespace SLeepApnea.Server.Migrations
{
    public partial class roleess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roless_Doctors_DoctorID",
                table: "Roless");

            migrationBuilder.DropForeignKey(
                name: "FK_Roless_Patients_PatientID",
                table: "Roless");

            migrationBuilder.DropIndex(
                name: "IX_Roless_DoctorID",
                table: "Roless");

            migrationBuilder.DropIndex(
                name: "IX_Roless_PatientID",
                table: "Roless");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Roless");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Roless");

            migrationBuilder.AddColumn<string>(
                name: "rolename",
                table: "Roless",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rolename",
                table: "Roless");

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Roless",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Roless",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roless_DoctorID",
                table: "Roless",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Roless_PatientID",
                table: "Roless",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roless_Doctors_DoctorID",
                table: "Roless",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roless_Patients_PatientID",
                table: "Roless",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
