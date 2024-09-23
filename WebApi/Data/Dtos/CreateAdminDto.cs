using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class CreateAdminDto {

    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O usuário precisa de um cpf")]
    [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
    public string Cpf { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }

}
