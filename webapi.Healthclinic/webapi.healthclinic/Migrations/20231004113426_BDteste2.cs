using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapihealthclinic.Migrations
{
    /// <inheritdoc />
    public partial class BDteste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdComentario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdComentario",
                table: "Consulta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdComentario",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdComentario",
                table: "Consulta",
                column: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta",
                column: "IdComentario",
                principalTable: "Comentario",
                principalColumn: "IdComentario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
