using System.Text.Json.Serialization;

namespace Estoque.Dtos.Pedido;

public class ReadItemPedidoDto {
    [JsonPropertyName("itemPedidoKey")]
    public int ItemPedidoKey { get; set; }
    [JsonPropertyName("ProductId")]
    public int ProductId { get; set; }
    [JsonPropertyName("Quantidade")]
    public int Quantidade { get; set; }
}