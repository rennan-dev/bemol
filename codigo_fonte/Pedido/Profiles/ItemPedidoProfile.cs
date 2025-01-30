using AutoMapper;
using Pedido.Dtos.ItemPedidos;
using Pedido.Models;

namespace Pedido.Profiles;

public class ItemPedidoProfile : Profile {
    public ItemPedidoProfile() {
        CreateMap<CreateItemPedidoDto, ItemPedido>();
        CreateMap<ItemPedido, ReadItemPedidoDto>();
        CreateMap<ReadItemPedidoDto, ItemPedido>();
    }
}