using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Data.PedidoRepository;

public class PedidoRepository : IPedidoRepository {

    private readonly AppDbContext _context;
    public PedidoRepository(AppDbContext context) {
        _context = context;
    }

    public void CreatePedido(PedidoCliente pedido) {
        if(pedido==null) {
            throw new ArgumentNullException(nameof(pedido));
        }
        _context.Pedidos.Add(pedido);
    }

    public IEnumerable<PedidoCliente> GetAllPedido() {
        //return _context.Pedidos.ToList();
        return _context.Pedidos.Include(p => p.Itens).ToList();
    }

    public PedidoCliente GetPedidoById(int id) => _context.Pedidos.FirstOrDefault(c => c.PedidoKey == id);

    public void SaveChanges() {
        _context.SaveChanges();
    }
}