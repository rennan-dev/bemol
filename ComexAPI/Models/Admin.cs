using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Models;
public class Admin : IdentityUser {
    
    public Admin() : base() { }
}
