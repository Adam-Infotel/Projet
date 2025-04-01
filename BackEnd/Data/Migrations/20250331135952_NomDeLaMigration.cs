using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomDeLaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "personne",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "personne",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isConnected",
                table: "personne",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "isConnected",
                table: "personne");
        }
    }
}
