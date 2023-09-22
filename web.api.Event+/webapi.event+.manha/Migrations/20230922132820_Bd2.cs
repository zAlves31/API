using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.event_.manha.Migrations
{
    /// <inheritdoc />
    public partial class Bd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ComentarioEvento",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ComentarioEvento");
        }
    }
}
