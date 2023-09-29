using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class bd99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Consulta");

            migrationBuilder.AddColumn<DateTime>(
                name: "HorarioAgendamento",
                table: "Consulta",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAgendamento",
                table: "Consulta");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Consulta",
                type: "VARCHAR",
                nullable: false,
                defaultValue: "");
        }
    }
}
