using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DAL.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pharmacy",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientRegsPatientId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pharmacyStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_pharmacy_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pharmacy_patientReg_PatientRegsPatientId",
                        column: x => x.PatientRegsPatientId,
                        principalTable: "patientReg",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_DoctorId",
                table: "pharmacy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_PatientRegsPatientId",
                table: "pharmacy",
                column: "PatientRegsPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pharmacy");
        }
    }
}
