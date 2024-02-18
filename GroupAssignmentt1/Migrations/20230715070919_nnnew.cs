using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupAssignmentt1.Migrations
{
    /// <inheritdoc />
    public partial class nnnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Patients_PatientRegNo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_PatientRegNo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PatientRegNo",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientRegNo",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_PatientRegNo",
                table: "Services",
                column: "PatientRegNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Patients_PatientRegNo",
                table: "Services",
                column: "PatientRegNo",
                principalTable: "Patients",
                principalColumn: "RegNo");
        }
    }
}
