using System.ComponentModel.DataAnnotations;
using Pedido.Dtos.ItemPedidos;
using Pedido.Models;

namespace Pedido.Dtos.Pedidos;

public class CreatePedidoDto {
    [Required] public List<CreateItemPedidoDto> Itens { get; set; } = new List<CreateItemPedidoDto>();
}