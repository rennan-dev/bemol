using System.ComponentModel.DataAnnotations;

namespace Pedido.Models;

public class PedidoCliente {
    [Key][Required] public int PedidoKey { get; set; }
    [Required] public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    [Required] public string Status { get; set; }
}