using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models; 
public class Produto {

    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio ou nulo.")]
    [StringLength(100, ErrorMessage = "O nome do produto não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; }

    [StringLength(500, ErrorMessage = "A descrição do produto não pode ultrapassar 500 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O preço do produto não pode ser vazio ou nulo.")]
    [Range(1, double.MaxValue, ErrorMessage = "O valor do produto precisa ser maior que zero")]
    public double PrecoUnitario { get; set; }

    [Required(ErrorMessage = "A quantidade do produto não pode ser vazio ou nulo.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade do produto não pode ser menor que zero")]
    public int Quantidade { get; set; }
}
