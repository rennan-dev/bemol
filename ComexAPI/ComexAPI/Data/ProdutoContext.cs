using ComexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data; 
public class ProdutoContext : DbContext {

    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts) {
        
    }

    public DbSet<Produto> Produtos { get; set; }
}