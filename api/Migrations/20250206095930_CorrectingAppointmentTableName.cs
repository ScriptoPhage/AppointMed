using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingAppointmentTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_Doctors_DoctorId",
                table: "Appoitments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appoitments",
                table: "Appoitments");

            migrationBuilder.RenameTable(
                name: "Appoitments",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appoitments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appoitments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appoitments",
                newName: "IX_Appoitments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appoitments",
                table: "Appoitments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_Doctors_DoctorId",
                table: "Appoitments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
