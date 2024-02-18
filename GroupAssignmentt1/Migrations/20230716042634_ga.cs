using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupAssignmentt1.Migrations
{
    /// <inheritdoc />
    public partial class ga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Patients");
        }
    }
}
