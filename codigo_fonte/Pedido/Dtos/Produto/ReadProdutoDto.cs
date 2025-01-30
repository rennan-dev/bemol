using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pedido.Dtos.Produto;

public class ReadProdutoDto {
    
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }
    
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    
    [JsonPropertyName("quantidadeDisponivel")]
    public int QuantidadeDisponivel { get; set; }
    
    [JsonPropertyName("preco")]
    public decimal Preco { get; set; }
}