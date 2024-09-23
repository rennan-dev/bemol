using System.ComponentModel.DataAnnotations;

namespace WebApi.Models; 
public class Livro {

    [Required]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Autor { get; set; }

    [Required]  
    public string Isbn { get; set; }

    [Required]
    public DateTime DataPublicacao { get; set; }

    public bool EstaEmprestado { get; set; }

    public int? ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
}
