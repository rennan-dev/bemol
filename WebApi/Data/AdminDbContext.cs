using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data; 
public class AdminDbContext : IdentityDbContext<Admin> {

    public AdminDbContext(DbContextOptions<AdminDbContext> opts) : base(opts) { }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
}
