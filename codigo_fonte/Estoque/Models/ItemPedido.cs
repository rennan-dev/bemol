using System.ComponentModel.DataAnnotations;

namespace Estoque.Models;

public class ItemPedido {
    [Key][Required] public int ItemPedidoKey { get; set; }
    [Required] public int ProductId { get; set; }
    [Required] public int Quantidade { get; set; }
}