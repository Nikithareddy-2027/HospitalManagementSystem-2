using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DAL.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultFee = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReEnterPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReEnterPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "patientReg",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardNumber = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientReg", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorsDoctorId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_pharmacy_doctor_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pharmacy_patientReg_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patientReg",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_DoctorId",
                table: "pharmacy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_DoctorsDoctorId",
                table: "pharmacy",
                column: "DoctorsDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_PatientId",
                table: "pharmacy",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "pharmacy");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patientReg");
        }
    }
}
