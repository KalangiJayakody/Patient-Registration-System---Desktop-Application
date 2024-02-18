using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupAssignmentt1.Migrations
{
    /// <inheritdoc />
    public partial class dew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Doctor",
                table: "Patients",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patients",
                newName: "Doctor");
        }
    }
}
