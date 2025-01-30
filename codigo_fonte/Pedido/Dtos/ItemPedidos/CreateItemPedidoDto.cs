using System.ComponentModel.DataAnnotations;

namespace Pedido.Dtos.ItemPedidos;

public class CreateItemPedidoDto {
    [Required] public int ProductId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    [Required] public int Quantidade { get; set; } 
}