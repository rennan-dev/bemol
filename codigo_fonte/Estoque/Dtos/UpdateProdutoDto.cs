using System.ComponentModel.DataAnnotations;

namespace Estoque.Dtos;

public class UpdateProdutoDto {
    [Required] public int QuantidadeDisponivel { get; set; }
}