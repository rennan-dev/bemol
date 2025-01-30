using AutoMapper;
using Pedido.Dtos.Pedidos;
using Pedido.Dtos.Produto;
using Pedido.Models;

namespace Pedido.Profiles;

public class PedidoProfile : Profile {
    public PedidoProfile() {
        CreateMap<CreatePedidoDto, PedidoCliente>();
        CreateMap<PedidoCliente, ReadPedidoDto>().ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
        CreateMap<ReadPedidoDto, PedidoCliente>();

        CreateMap<ReadProdutoDto, Produto>().ForMember(destino => destino.ProductIdExterno, opt => opt.MapFrom(src=>src.ProductId));
    }
}