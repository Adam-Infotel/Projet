using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "personne");

            migrationBuilder.RenameColumn(
                name: "isConnected",
                table: "personne",
                newName: "IsConnected");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "personne",
                newName: "Telephone");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConnected",
                table: "personne",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "personne",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "personne",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "personne",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "personne",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodePostal",
                table: "personne",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "personne",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastConnexion",
                table: "personne",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotDePasse",
                table: "personne",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pays",
                table: "personne",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "personne",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "LastConnexion",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "MotDePasse",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "Pays",
                table: "personne");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "personne");

            migrationBuilder.RenameColumn(
                name: "IsConnected",
                table: "personne",
                newName: "isConnected");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "personne",
                newName: "Phone_number");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "personne",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "personne",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "isConnected",
                table: "personne",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "personne",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "personne",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
