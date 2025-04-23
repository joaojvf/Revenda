using AutoMapper;
using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;
using Revenda.Core.UseCases.Revenda.GetRevendaById;

namespace Revenda.Core.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RevendaEntity, RevendaDto>()
                .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones))
                .ForMember(dest => dest.NomesContato, opt => opt.MapFrom(src => src.NomesContato))
                .ForMember(dest => dest.EnderecosEntrega, opt => opt.MapFrom(src => src.EnderecosEntrega));
            
            CreateMap<Telefone, TelefoneDto>();
            CreateMap<NomeContato, NomeContatoDto>();
            CreateMap<EnderecoEntrega, EnderecoEntregaDto>();

            
            CreateMap<CreateRevendaCommand, RevendaEntity>()
                .ForMember(dest => dest.Telefones, opt => opt.Ignore())
                .ForMember(dest => dest.NomesContato, opt => opt.Ignore())
                .ForMember(dest => dest.EnderecosEntrega, opt => opt.Ignore())
                .ForMember(dest => dest.PedidosCliente, opt => opt.Ignore())
                .ForMember(dest => dest.Pedidos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CreateTelefoneDto, Telefone>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RevendaId, opt => opt.Ignore())
                .ForMember(dest => dest.Revenda, opt => opt.Ignore());
            CreateMap<CreateNomeContatoDto, NomeContato>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.RevendaId, opt => opt.Ignore())
                 .ForMember(dest => dest.Revenda, opt => opt.Ignore());
            CreateMap<CreateEnderecoEntregaDto, EnderecoEntrega>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.RevendaId, opt => opt.Ignore())
                 .ForMember(dest => dest.Revenda, opt => opt.Ignore());

            CreateMap<PedidoCliente, PedidoClienteDto>()
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
            CreateMap<ItemPedidoCliente, ItemPedidoClienteDto>();
        }
    }
}
