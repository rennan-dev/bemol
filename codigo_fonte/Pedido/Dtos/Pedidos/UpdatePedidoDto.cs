using System.ComponentModel.DataAnnotations;

namespace Pedido.Dtos.Pedidos;

public class UpdatePedidoDto {
    [Required] public string Status { get; set; }
}