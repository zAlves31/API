using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class bd90 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Medico",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Medico",
                type: "CHAR(14)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Medico");
        }
    }
}
