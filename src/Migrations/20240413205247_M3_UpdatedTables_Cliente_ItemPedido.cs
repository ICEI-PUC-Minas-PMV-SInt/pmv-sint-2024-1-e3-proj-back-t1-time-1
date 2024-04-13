using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharma.Migrations
{
    /// <inheritdoc />
    public partial class M3_UpdatedTables_Cliente_ItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosClientes",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DtPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NtFiscal = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPedido = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosClientes", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_PedidosClientes_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPedidos",
                columns: table => new
                {
                    IdItemProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QtProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    VlUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    VlTotalItem = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPedidos", x => x.IdItemProduto);
                    table.ForeignKey(
                        name: "FK_ItemsPedidos_PedidosClientes_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "PedidosClientes",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedidos_IdPedido",
                table: "ItemsPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosClientes_IdCliente",
                table: "PedidosClientes",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsPedidos");

            migrationBuilder.DropTable(
                name: "PedidosClientes");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
