using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Estoque.Models;

namespace Estoque.Dtos.Pedido;

public class ReadPedidoDto {
    public int PedidoKey { get; set; }
    [JsonPropertyName("Itens")]
    public List<ReadItemPedidoDto> Itens { get; set; } 
    public string Status { get; set; }
}