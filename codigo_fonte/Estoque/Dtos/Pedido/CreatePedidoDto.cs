using System.ComponentModel.DataAnnotations;
using Estoque.Dtos.Pedido;
using Estoque.Models;

namespace Pedido.Dtos.Pedidos;

public class CreatePedidoDto {
    [Required] public List<CreateItemPedidoDto> Itens { get; set; }
}