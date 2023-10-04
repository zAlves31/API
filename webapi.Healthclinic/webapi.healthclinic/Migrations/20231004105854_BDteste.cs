using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class BDteste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioAgendamento",
                table: "Consulta",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioAgendamento",
                table: "Consulta",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }
    }
}
