using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AulaVinteUm.Migrations
{
    /// <inheritdoc />
    public partial class updateDbSistemaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Produtos_ProdutoId",
                table: "ItemVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVendas",
                table: "ItemVendas");

            migrationBuilder.RenameTable(
                name: "ItemVendas",
                newName: "ItensVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVendas_VendaId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVendas_ProdutoId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda",
                column: "ItemVendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Produtos_ProdutoId",
                table: "ItensVenda",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Produtos_ProdutoId",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda");

            migrationBuilder.RenameTable(
                name: "ItensVenda",
                newName: "ItemVendas");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_VendaId",
                table: "ItemVendas",
                newName: "IX_ItemVendas_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_ProdutoId",
                table: "ItemVendas",
                newName: "IX_ItemVendas_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVendas",
                table: "ItemVendas",
                column: "ItemVendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Produtos_ProdutoId",
                table: "ItemVendas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
