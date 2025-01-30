using Pedido.Models;
using Microsoft.EntityFrameworkCore;

namespace Pedido.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {

    }

    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<PedidoCliente> Pedidos { get; set; }
    public DbSet<Produto> Produtos {get; set; }
}