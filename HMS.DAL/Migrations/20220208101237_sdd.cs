using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DAL.Migrations
{
    public partial class sdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reception",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId1 = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientRegPatientId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_reception_doctor_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reception_patientReg_patientRegPatientId",
                        column: x => x.patientRegPatientId,
                        principalTable: "patientReg",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reception_DoctorId1",
                table: "reception",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_reception_patientRegPatientId",
                table: "reception",
                column: "patientRegPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reception");
        }
    }
}
