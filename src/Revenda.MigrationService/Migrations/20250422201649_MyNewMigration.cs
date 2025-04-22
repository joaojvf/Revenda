using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Revenda.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class MyNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecosEntrega",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosEntrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecosEntrega_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomesContato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    RevendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomesContato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomesContato_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosAmbev",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TentativasEnvio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosAmbev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosAmbev_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificacaoCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosCliente_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RevendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Revendas_RevendaId",
                        column: x => x.RevendaId,
                        principalTable: "Revendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidoAmbev",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidoAmbev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidoAmbev_PedidosAmbev_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "PedidosAmbev",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidoCliente_PedidosCliente_PedidoClienteId",
                        column: x => x.PedidoClienteId,
                        principalTable: "PedidosCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Revendas",
                columns: new[] { "Id", "Cnpj", "Email", "NomeFantasia", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b"), "51468333000178", "compras@pontocertobebidas.com", "Ponto Certo Bebidas", "Bebidas Geladas Sempre ME" },
                    { new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a"), "71039888000183", "contato@distribuidoraalegria.com.br", "Distribuidora Alegria", "Comércio de Bebidas Alegria Ltda." }
                });

            migrationBuilder.InsertData(
                table: "EnderecosEntrega",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("04b309dd-962d-4282-ab19-b28cff2306c8"), "Vila Industrial", "13000200", "Campinas", null, "SP", "Avenida dos Expedicionários", "2000", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("ab6a9eb5-933e-4cdd-9505-7a292f8958c5"), "Distrito Industrial", "13000100", "Campinas", "Galpão A", "SP", "Rua Principal", "100", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("fb04686a-9c1e-4f32-af61-c585d269603e"), "Centro", "20000050", "Rio de Janeiro", null, "RJ", "Rua das Flores", "50", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") }
                });

            migrationBuilder.InsertData(
                table: "NomesContato",
                columns: new[] { "Id", "IsPrincipal", "Nome", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("1406218f-2029-47d8-bf58-3d4debaf8d09"), true, "Carlos Pereira", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("71fb391b-7d07-4e32-9ffb-e579d5c65435"), true, "Roberto Lima", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") },
                    { new Guid("d381caf2-1653-4b05-a998-e67ea05f12ab"), false, "Ana Souza", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") }
                });

            migrationBuilder.InsertData(
                table: "PedidosAmbev",
                columns: new[] { "Id", "DataCriacao", "DataEnvio", "OrderId", "RevendaId", "Status", "TentativasEnvio" },
                values: new object[] { new Guid("da7594af-83d2-4e5f-8a5b-f3daed0b03c3"), new DateTime(2025, 4, 21, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 21, 14, 15, 0, 0, DateTimeKind.Utc), "_ORD_KJHGFD", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a"), 2, 1 });

            migrationBuilder.InsertData(
                table: "PedidosCliente",
                columns: new[] { "Id", "DataPedido", "IdentificacaoCliente", "RevendaId" },
                values: new object[] { new Guid("f07d8248-21aa-4b7e-b280-13f1e38448ec"), new DateTime(2025, 4, 20, 10, 30, 0, 0, DateTimeKind.Utc), "Bar Amigos da Esquina", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") });

            migrationBuilder.InsertData(
                table: "Telefones",
                columns: new[] { "Id", "Numero", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("4e8bd9bf-614f-4c42-8e41-8df74c45e6c0"), "11999998888", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("f3ea2588-753a-4d61-aba4-4994a8572417"), "1123456789", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("f7f13271-be12-40b7-91a4-eeb50bd0b12f"), "21988887777", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") }
                });

            migrationBuilder.InsertData(
                table: "ItensPedidoAmbev",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { new Guid("0047fb15-04fe-4bac-b839-0d2cd95d2220"), new Guid("da7594af-83d2-4e5f-8a5b-f3daed0b03c3"), "SKU-CERV-PILSEN-600", 800 },
                    { new Guid("14c173d8-2fd7-4977-828e-0bd52faf6a0f"), new Guid("da7594af-83d2-4e5f-8a5b-f3daed0b03c3"), "SKU-REFRI-COLA-2L", 400 }
                });

            migrationBuilder.InsertData(
                table: "ItensPedidoCliente",
                columns: new[] { "Id", "PedidoClienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { new Guid("741e854c-6d8b-46d7-acf5-e01e355b861b"), new Guid("f07d8248-21aa-4b7e-b280-13f1e38448ec"), "SKU-CERV-PILSEN-600", 120 },
                    { new Guid("c4b7f99e-410a-4dac-90ee-40e469e15198"), new Guid("f07d8248-21aa-4b7e-b280-13f1e38448ec"), "SKU-REFRI-COLA-2L", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosEntrega_RevendaId",
                table: "EnderecosEntrega",
                column: "RevendaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidoAmbev_PedidoId",
                table: "ItensPedidoAmbev",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidoCliente_PedidoClienteId",
                table: "ItensPedidoCliente",
                column: "PedidoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NomesContato_RevendaId",
                table: "NomesContato",
                column: "RevendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosAmbev_RevendaId",
                table: "PedidosAmbev",
                column: "RevendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosCliente_RevendaId",
                table: "PedidosCliente",
                column: "RevendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_RevendaId",
                table: "Telefones",
                column: "RevendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecosEntrega");

            migrationBuilder.DropTable(
                name: "ItensPedidoAmbev");

            migrationBuilder.DropTable(
                name: "ItensPedidoCliente");

            migrationBuilder.DropTable(
                name: "NomesContato");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "PedidosAmbev");

            migrationBuilder.DropTable(
                name: "PedidosCliente");

            migrationBuilder.DropTable(
                name: "Revendas");
        }
    }
}
