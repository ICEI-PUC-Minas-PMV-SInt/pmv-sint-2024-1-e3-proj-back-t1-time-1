using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharma.Migrations
{
    /// <inheritdoc />
    public partial class M6UpdatedTable_Localizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Localizacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Localizacoes_UsuarioId",
                table: "Localizacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localizacoes_Usuarios_UsuarioId",
                table: "Localizacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localizacoes_Usuarios_UsuarioId",
                table: "Localizacoes");

            migrationBuilder.DropIndex(
                name: "IX_Localizacoes_UsuarioId",
                table: "Localizacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Localizacoes");
        }
    }
}
