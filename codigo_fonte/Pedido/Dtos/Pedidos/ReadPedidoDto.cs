using System.ComponentModel.DataAnnotations;
using Pedido.Dtos.ItemPedidos;
using Pedido.Models;

namespace Pedido.Dtos.Pedidos;

public class ReadPedidoDto {
    public int PedidoKey { get; set; }
    public List<ReadItemPedidoDto> Itens { get; set; } 
    public string Status { get; set; }
}