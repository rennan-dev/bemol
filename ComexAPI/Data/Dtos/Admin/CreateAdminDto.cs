using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class CreateAdminDto {

    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }

}
