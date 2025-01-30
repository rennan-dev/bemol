using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos;

public class CreateProdutoDto {
    [Required] public string Nome { get; set; }
    [Required] public int QuantidadeDisponivel { get; set; }
    [Required] public float Preco { get; set; }
}