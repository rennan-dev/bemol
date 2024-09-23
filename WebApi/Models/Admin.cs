using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Models; 
public class Admin : IdentityUser {
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }

    public Admin() : base() { }
}
