using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos;
public class LoginAdminDto {

    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}
