using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharma.Migrations
{
    /// <inheritdoc />
    public partial class M7AddTableMovimentacaoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimentacaoEstoque",
                columns: table => new
                {
                    IdMovimentacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdItemPedido = table.Column<int>(nullable: false),
                    QtProduto = table.Column<int>(nullable: false),
                    TpMovimentacao = table.Column<string>(nullable: false),
                    DtMovimentacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoEstoque", x => x.IdMovimentacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoEstoque");
        }

    }
}
