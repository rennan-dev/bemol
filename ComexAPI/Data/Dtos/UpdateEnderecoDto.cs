using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos; 
public class UpdateEnderecoDto {

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
}
