using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class EmprestaLivroDto {

    [Required(ErrorMessage = "Precisa de um id de um livro para fazer empréstimo.")]
    public int Id { get; set; }
}
