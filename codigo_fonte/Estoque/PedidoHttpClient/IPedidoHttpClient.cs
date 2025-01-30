using Estoque.Dtos.Pedido;

namespace Estoque.PedidoHttpClient;

public interface IPedidoHttpClient {
    Task UpdatePedido(int pedidoId, UpdatePedidoDto updatePedidoDto);
}