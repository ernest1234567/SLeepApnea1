using Microsoft.EntityFrameworkCore.Migrations;

namespace SLeepApnea.Server.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "VitalDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VitalDatas_PatientID",
                table: "VitalDatas",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalDatas_Patients_PatientID",
                table: "VitalDatas",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VitalDatas_Patients_PatientID",
                table: "VitalDatas");

            migrationBuilder.DropIndex(
                name: "IX_VitalDatas_PatientID",
                table: "VitalDatas");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "VitalDatas");
        }
    }
}
