using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class CreateClienteDto {

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Cpf { get; set; }
}
