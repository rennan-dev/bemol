using System.ComponentModel.DataAnnotations;

namespace WebApi.Models; 
public class Cliente {

    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Cpf { get; set; }

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
