using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DAL.Migrations
{
    public partial class jh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pharmacy_doctor_DoctorId",
                table: "pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_pharmacy_DoctorId",
                table: "pharmacy");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorsDoctorId",
                table: "pharmacy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_DoctorsDoctorId",
                table: "pharmacy",
                column: "DoctorsDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_pharmacy_doctor_DoctorsDoctorId",
                table: "pharmacy",
                column: "DoctorsDoctorId",
                principalTable: "doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pharmacy_doctor_DoctorsDoctorId",
                table: "pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_pharmacy_DoctorsDoctorId",
                table: "pharmacy");

            migrationBuilder.DropColumn(
                name: "DoctorsDoctorId",
                table: "pharmacy");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "pharmacy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "pharmacy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_DoctorId",
                table: "pharmacy",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_pharmacy_doctor_DoctorId",
                table: "pharmacy",
                column: "DoctorId",
                principalTable: "doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
