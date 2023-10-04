using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class BD123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdConsulta",
                table: "Comentario",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdConsulta",
                table: "Comentario",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Consulta_IdConsulta",
                table: "Comentario",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "IdConsulta",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Consulta_IdConsulta",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_IdConsulta",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Comentario");
        }
    }
}
