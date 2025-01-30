using Pedido.Dtos.Pedidos;

namespace Pedido.RabbitMqClient;

public interface IRabbitMqClient {

    public void EnviarPedidoParaEstoque(ReadPedidoDto readPedidoDto);
}