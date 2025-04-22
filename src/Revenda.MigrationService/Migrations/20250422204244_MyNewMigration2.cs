using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Revenda.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class MyNewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("04b309dd-962d-4282-ab19-b28cff2306c8"));

            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("ab6a9eb5-933e-4cdd-9505-7a292f8958c5"));

            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("fb04686a-9c1e-4f32-af61-c585d269603e"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoAmbev",
                keyColumn: "Id",
                keyValue: new Guid("0047fb15-04fe-4bac-b839-0d2cd95d2220"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoAmbev",
                keyColumn: "Id",
                keyValue: new Guid("14c173d8-2fd7-4977-828e-0bd52faf6a0f"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoCliente",
                keyColumn: "Id",
                keyValue: new Guid("741e854c-6d8b-46d7-acf5-e01e355b861b"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoCliente",
                keyColumn: "Id",
                keyValue: new Guid("c4b7f99e-410a-4dac-90ee-40e469e15198"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("1406218f-2029-47d8-bf58-3d4debaf8d09"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("71fb391b-7d07-4e32-9ffb-e579d5c65435"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("d381caf2-1653-4b05-a998-e67ea05f12ab"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("4e8bd9bf-614f-4c42-8e41-8df74c45e6c0"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("f3ea2588-753a-4d61-aba4-4994a8572417"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("f7f13271-be12-40b7-91a4-eeb50bd0b12f"));

            migrationBuilder.DeleteData(
                table: "PedidosAmbev",
                keyColumn: "Id",
                keyValue: new Guid("da7594af-83d2-4e5f-8a5b-f3daed0b03c3"));

            migrationBuilder.DeleteData(
                table: "PedidosCliente",
                keyColumn: "Id",
                keyValue: new Guid("f07d8248-21aa-4b7e-b280-13f1e38448ec"));

            migrationBuilder.InsertData(
                table: "EnderecosEntrega",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Distrito Industrial", "13000100", "Campinas", "Galpão A", "SP", "Rua Principal", "100", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Vila Industrial", "13000200", "Campinas", null, "SP", "Avenida dos Expedicionários", "2000", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), "Centro", "20000050", "Rio de Janeiro", null, "RJ", "Rua das Flores", "50", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") }
                });

            migrationBuilder.InsertData(
                table: "NomesContato",
                columns: new[] { "Id", "IsPrincipal", "Nome", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, "Carlos Pereira", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), false, "Ana Souza", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), true, "Roberto Lima", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") }
                });

            migrationBuilder.InsertData(
                table: "PedidosAmbev",
                columns: new[] { "Id", "DataCriacao", "DataEnvio", "OrderId", "RevendaId", "Status", "TentativasEnvio" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 4, 21, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 21, 14, 15, 0, 0, DateTimeKind.Utc), "_ORD_KJHGFD", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a"), 2, 1 });

            migrationBuilder.InsertData(
                table: "PedidosCliente",
                columns: new[] { "Id", "DataPedido", "IdentificacaoCliente", "RevendaId" },
                values: new object[] { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 4, 20, 10, 30, 0, 0, DateTimeKind.Utc), "Bar Amigos da Esquina", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") });

            migrationBuilder.InsertData(
                table: "Telefones",
                columns: new[] { "Id", "Numero", "RevendaId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "11999998888", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "1123456789", new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a") },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "21988887777", new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b") }
                });

            migrationBuilder.InsertData(
                table: "ItensPedidoAmbev",
                columns: new[] { "Id", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "SKU-CERV-PILSEN-600", 800 },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "SKU-REFRI-COLA-2L", 400 }
                });

            migrationBuilder.InsertData(
                table: "ItensPedidoCliente",
                columns: new[] { "Id", "PedidoClienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("77777777-7777-7777-7777-777777777777"), "SKU-CERV-PILSEN-600", 120 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("77777777-7777-7777-7777-777777777777"), "SKU-REFRI-COLA-2L", 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "EnderecosEntrega",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoAmbev",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoAmbev",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoCliente",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "ItensPedidoCliente",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "NomesContato",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Telefones",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "PedidosAmbev",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "PedidosCliente",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

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
        }
    }
}
