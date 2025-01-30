using System.ComponentModel.DataAnnotations;

namespace Pedido.Dtos.ItemPedidos;

public class ReadItemPedidoDto {
    public int ItemPedidoKey { get; set; }
    public int ProductId { get; set; }
    public int Quantidade { get; set; }
}