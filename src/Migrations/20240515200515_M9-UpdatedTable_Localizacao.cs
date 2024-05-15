using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharma.Migrations
{
    /// <inheritdoc />
    public partial class M9UpdatedTable_Localizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_localizacao",
                table: "Localizacoes",
                newName: "IdLocalizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLocalizacao",
                table: "Localizacoes",
                newName: "Id_localizacao");
        }
    }
}
