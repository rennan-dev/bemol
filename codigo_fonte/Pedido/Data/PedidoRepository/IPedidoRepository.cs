using Pedido.Models;

namespace Pedido.Data.PedidoRepository;

public interface IPedidoRepository {
    void SaveChanges();
    IEnumerable<PedidoCliente> GetAllPedido();
    PedidoCliente GetPedidoById(int id);
    void CreatePedido(PedidoCliente pedido);
}