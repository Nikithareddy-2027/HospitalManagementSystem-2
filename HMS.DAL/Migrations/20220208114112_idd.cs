using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DAL.Migrations
{
    public partial class idd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_doctor_DoctorId1",
                table: "reception");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_patientReg_patientRegPatientId",
                table: "reception");

            migrationBuilder.DropIndex(
                name: "IX_reception_DoctorId1",
                table: "reception");

            migrationBuilder.DropIndex(
                name: "IX_reception_patientRegPatientId",
                table: "reception");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "reception");

            migrationBuilder.DropColumn(
                name: "patientRegPatientId",
                table: "reception");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "reception",
                newName: "PatientName");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "reception",
                newName: "DoctorName");

            migrationBuilder.AddColumn<int>(
                name: "PatientWeight",
                table: "reception",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientWeight",
                table: "reception");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "reception",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DoctorName",
                table: "reception",
                newName: "DoctorId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "reception",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "patientRegPatientId",
                table: "reception",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reception_DoctorId1",
                table: "reception",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_reception_patientRegPatientId",
                table: "reception",
                column: "patientRegPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_doctor_DoctorId1",
                table: "reception",
                column: "DoctorId1",
                principalTable: "doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_patientReg_patientRegPatientId",
                table: "reception",
                column: "patientRegPatientId",
                principalTable: "patientReg",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
