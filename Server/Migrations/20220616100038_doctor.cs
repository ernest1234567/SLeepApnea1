using Microsoft.EntityFrameworkCore.Migrations;

namespace SLeepApnea.Server.Migrations
{
    public partial class doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "VitalDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VitalDatas_DoctorID",
                table: "VitalDatas",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalDatas_Doctors_DoctorID",
                table: "VitalDatas",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VitalDatas_Doctors_DoctorID",
                table: "VitalDatas");

            migrationBuilder.DropIndex(
                name: "IX_VitalDatas_DoctorID",
                table: "VitalDatas");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "VitalDatas");
        }
    }
}
