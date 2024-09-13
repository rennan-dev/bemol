using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models; 
public class Cliente {

    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Profissao { get; set; }
    [Required]
    public string Telefone { get; set; }
    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
