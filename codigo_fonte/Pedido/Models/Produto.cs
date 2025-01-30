using System.ComponentModel.DataAnnotations;

namespace Pedido.Models;

public class Produto {
    [Key] [Required] public int ProductId { get; set; }
    [Required] public int ProductIdExterno { get; set; }
    [Required] public string Nome { get; set; }
    [Required] public int QuantidadeDisponivel { get; set; }
    [Required] public float Preco { get; set; }
}