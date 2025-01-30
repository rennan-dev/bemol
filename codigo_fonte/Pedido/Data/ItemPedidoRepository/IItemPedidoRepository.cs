using Pedido.Models;

namespace Pedido.Data.ItemPedidoRepository;

public interface IItemPedidoRepository {
    void SaveChanges();
    IEnumerable<ItemPedido> GetAllItemPedido();
    ItemPedido GetItemPedidoById(int id);
    void CreateItemPedido(ItemPedido itemPedido);
}