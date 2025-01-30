using Pedido.Data;
using Pedido.Models;

namespace Pedido.Data.ItemPedidoRepository;

public class ItemPedidoRepository : IItemPedidoRepository {

    private readonly AppDbContext _context;
    public ItemPedidoRepository(AppDbContext context) {
        _context = context;
    }

    public void CreateItemPedido(ItemPedido itemPedido) {
        if(itemPedido==null) {
            throw new ArgumentNullException(nameof(itemPedido));
        }
        _context.ItensPedido.Add(itemPedido);
    }

    public IEnumerable<ItemPedido> GetAllItemPedido() {
        return _context.ItensPedido.ToList();
    }

    public ItemPedido GetItemPedidoById(int id) => _context.ItensPedido.FirstOrDefault(c => c.ItemPedidoKey == id);

    public void SaveChanges() {
        _context.SaveChanges();
    }
}