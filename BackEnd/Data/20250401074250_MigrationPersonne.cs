using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data
{
    /// <inheritdoc />
    public partial class MigrationPersonne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                table: "personne",
                newName: "Phone_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "personne",
                newName: "Phone_Number");
        }
    }
}
