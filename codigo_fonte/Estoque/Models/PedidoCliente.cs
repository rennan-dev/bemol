using System.ComponentModel.DataAnnotations;

namespace Estoque.Models;

public class PedidoCliente {
    [Key][Required] public int PedidoKey { get; set; }
    [Required] public List<ItemPedido> Itens { get; set; }
    [Required] public string Status { get; set; }
}