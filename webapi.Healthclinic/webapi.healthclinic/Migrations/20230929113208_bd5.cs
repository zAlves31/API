using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class bd5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Prontuario",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Comentario",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(256)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Prontuario",
                type: "VARCHAR(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Comentario",
                type: "VARCHAR(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
