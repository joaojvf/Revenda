using Revenda.Core.Entities;

namespace Revenda.Core.Helpers
{
    public static class DefaultSeedData
    {
        // Revendas
        private static readonly Guid Revenda1Id = new Guid("f5b5a6d8-7c3e-4a8d-b0f3-3a0e5d7b2e1a");
        private static readonly Guid Revenda2Id = new Guid("a2e1d7b3-5d0e-4f3a-8b0c-6a8d7c3e5f5b");

        // Itens para Revenda 1
        private static readonly Guid Tel1Rev1Id = new Guid("11111111-1111-1111-1111-111111111111");
        private static readonly Guid Tel2Rev1Id = new Guid("22222222-2222-2222-2222-222222222222");
        private static readonly Guid ContatoPrincipalRev1Id = new Guid("33333333-3333-3333-3333-333333333333");
        private static readonly Guid ContatoSecundarioRev1Id = new Guid("44444444-4444-4444-4444-444444444444");
        private static readonly Guid Endereco1Rev1Id = new Guid("55555555-5555-5555-5555-555555555555");
        private static readonly Guid Endereco2Rev1Id = new Guid("66666666-6666-6666-6666-666666666666");
        private static readonly Guid PedidoCliente1Rev1Id = new Guid("77777777-7777-7777-7777-777777777777");
        private static readonly Guid Item1PedCliente1Rev1Id = new Guid("88888888-8888-8888-8888-888888888888");
        private static readonly Guid Item2PedCliente1Rev1Id = new Guid("99999999-9999-9999-9999-999999999999");
        private static readonly Guid Pedido1Rev1Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly Guid Item1Ped1Rev1Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        private static readonly Guid Item2Ped1Rev1Id = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc");

        // Itens para Revenda 2
        private static readonly Guid Tel1Rev2Id = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd");
        private static readonly Guid ContatoPrincipalRev2Id = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        private static readonly Guid Endereco1Rev2Id = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");


        public static readonly List<RevendaEntity> DefaultRevendas = new()
    {
        new RevendaEntity
        {
            Id = Revenda1Id,
            Cnpj = "71039888000183",
            RazaoSocial = "Comércio de Bebidas Alegria Ltda.",
            NomeFantasia = "Distribuidora Alegria",
            Email = "contato@distribuidoraalegria.com.br"
        },
        new RevendaEntity
        {
            Id = Revenda2Id,
            Cnpj = "51468333000178",
            RazaoSocial = "Bebidas Geladas Sempre ME",
            NomeFantasia = "Ponto Certo Bebidas",
            Email = "compras@pontocertobebidas.com"
        }
    };

        public static readonly List<Telefone> DefaultTelefones = new()
    {
        new Telefone { Id = Tel1Rev1Id, Numero = "11999998888", RevendaId = Revenda1Id },
        new Telefone { Id = Tel2Rev1Id, Numero = "1123456789", RevendaId = Revenda1Id },
        new Telefone { Id = Tel1Rev2Id, Numero = "21988887777", RevendaId = Revenda2Id }
    };

        public static readonly List<NomeContato> DefaultNomesContato = new()
    {
        new NomeContato { Id = ContatoPrincipalRev1Id, Nome = "Carlos Pereira", IsPrincipal = true, RevendaId = Revenda1Id },
        new NomeContato { Id = ContatoSecundarioRev1Id, Nome = "Ana Souza", IsPrincipal = false, RevendaId = Revenda1Id },
        new NomeContato { Id = ContatoPrincipalRev2Id, Nome = "Roberto Lima", IsPrincipal = true, RevendaId = Revenda2Id }
    };

        public static readonly List<EnderecoEntrega> DefaultEnderecosEntrega = new()
    {
        new EnderecoEntrega
        {
            Id = Endereco1Rev1Id,
            Logradouro = "Rua Principal", Numero = "100", Complemento = "Galpão A", Bairro = "Distrito Industrial",
            Cidade = "Campinas", Estado = "SP", Cep = "13000100", RevendaId = Revenda1Id
        },
        new EnderecoEntrega
        {
            Id = Endereco2Rev1Id,
            Logradouro = "Avenida dos Expedicionários", Numero = "2000", Bairro = "Vila Industrial",
            Cidade = "Campinas", Estado = "SP", Cep = "13000200", RevendaId = Revenda1Id
        },
        new EnderecoEntrega
        {
            Id = Endereco1Rev2Id,
            Logradouro = "Rua das Flores", Numero = "50", Bairro = "Centro",
            Cidade = "Rio de Janeiro", Estado = "RJ", Cep = "20000050", RevendaId = Revenda2Id
        }
    };

        public static readonly List<PedidoCliente> DefaultPedidosCliente = new()
    {
        new PedidoCliente
        {
            Id = PedidoCliente1Rev1Id,
            RevendaId = Revenda1Id,
            IdentificacaoCliente = "Bar Amigos da Esquina",
            DataPedido = new DateTime(2025, 4, 20, 10, 30, 0, DateTimeKind.Utc)
        }
    };

        public static readonly List<ItemPedidoCliente> DefaultItensPedidoCliente = new()
    {
        new ItemPedidoCliente { Id = Item1PedCliente1Rev1Id, PedidoClienteId = PedidoCliente1Rev1Id, ProdutoId = "SKU-CERV-PILSEN-600", Quantidade = 120 },
        new ItemPedidoCliente { Id = Item2PedCliente1Rev1Id, PedidoClienteId = PedidoCliente1Rev1Id, ProdutoId = "SKU-REFRI-COLA-2L", Quantidade = 50 }
    };

        public static readonly List<Pedido> DefaultPedidos = new()
    {
        new Pedido
        {
            Id = Pedido1Rev1Id, 
            RevendaId = Revenda1Id,
            DataCriacao = new DateTime(2025, 4, 21, 8, 0, 0, DateTimeKind.Utc),
            Status = StatusPedido.Enviado,
            OrderId = "_ORD_KJHGFD",
            DataEnvio = new DateTime(2025, 4, 21, 14, 15, 0, DateTimeKind.Utc),
            TentativasEnvio = 1,
        }
    };

        public static readonly List<ItemPedido> DefaultItensPedido = new()
    {
        new ItemPedido { Id = Item1Ped1Rev1Id, PedidoId = Pedido1Rev1Id, ProdutoId = "SKU-CERV-PILSEN-600", Quantidade = 800 },
        new ItemPedido { Id = Item2Ped1Rev1Id, PedidoId = Pedido1Rev1Id, ProdutoId = "SKU-REFRI-COLA-2L", Quantidade = 400 } 
    };
    }
}
