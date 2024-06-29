using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroNumeros.Migrations
{
    /// <inheritdoc />
    public partial class AddDataCriacaoToContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Contatos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumeroTel",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "NumeroTel",
                table: "Contatos");

            migrationBuilder.AlterColumn<string>(
                name: "Idade",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
