using ComexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data; 
public class ProdutoContext : DbContext {

    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts) {
        
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}