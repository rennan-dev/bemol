using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class UpdateLivroDto {

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Autor { get; set; }

    [Required]
    public string Isbn { get; set; }

    [Required]
    public DateTime DataPublicacao { get; set; }
}
