using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos; 
public class CreateCategoriaDto {
    [Required(ErrorMessage = "A categoria não pode ficar sem nome")]
    public string Nome { get; set; }
}
