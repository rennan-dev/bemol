using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models; 
public class Endereco {

    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Bairro { get; set; }
    [Required]
    public string Cidade { get; set; }
    [Required]
    public string Complemento { get; set; }
    [Required]
    public string Estado { get; set; }
    [Required]
    public string Rua { get; set; }
    [Required]
    public string Numero { get; set; }
    public virtual Cliente Cliente { get; set; }
}
