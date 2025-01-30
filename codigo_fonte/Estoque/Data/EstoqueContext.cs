using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data;

public class EstoqueContext : DbContext {
    public EstoqueContext(DbContextOptions<EstoqueContext> opts) : base(opts) {

    }

    public DbSet<Produto> Produtos { get; set; }

    //parte assíncrona
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<PedidoCliente> Pedidos { get; set; }
}