using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos.Pedido;

public class UpdatePedidoDto {
    [Required] public string Status { get; set; }
}