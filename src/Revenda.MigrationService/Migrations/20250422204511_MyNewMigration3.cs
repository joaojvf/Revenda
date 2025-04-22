using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Revenda.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class MyNewMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidoAmbev_PedidosAmbev_PedidoId",
                table: "ItensPedidoAmbev");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosAmbev_Revendas_RevendaId",
                table: "PedidosAmbev");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosAmbev",
                table: "PedidosAmbev");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedidoAmbev",
                table: "ItensPedidoAmbev");

            migrationBuilder.RenameTable(
                name: "PedidosAmbev",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "ItensPedidoAmbev",
                newName: "ItensPedido");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosAmbev_RevendaId",
                table: "Pedidos",
                newName: "IX_Pedidos_RevendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedidoAmbev_PedidoId",
                table: "ItensPedido",
                newName: "IX_ItensPedido_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedido",
                table: "ItensPedido",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Revendas_RevendaId",
                table: "Pedidos",
                column: "RevendaId",
                principalTable: "Revendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Revendas_RevendaId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedido",
                table: "ItensPedido");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "PedidosAmbev");

            migrationBuilder.RenameTable(
                name: "ItensPedido",
                newName: "ItensPedidoAmbev");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_RevendaId",
                table: "PedidosAmbev",
                newName: "IX_PedidosAmbev_RevendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedidoAmbev",
                newName: "IX_ItensPedidoAmbev_PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosAmbev",
                table: "PedidosAmbev",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedidoAmbev",
                table: "ItensPedidoAmbev",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidoAmbev_PedidosAmbev_PedidoId",
                table: "ItensPedidoAmbev",
                column: "PedidoId",
                principalTable: "PedidosAmbev",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosAmbev_Revendas_RevendaId",
                table: "PedidosAmbev",
                column: "RevendaId",
                principalTable: "Revendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
