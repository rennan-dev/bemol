using System.Text;
using System.Text.Json;
using Pedido.Dtos.Pedidos;
using RabbitMQ.Client;

namespace Pedido.RabbitMqClient;

public class RabbitMqClient : IRabbitMqClient {

    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqClient(IConfiguration configuration) {
        _configuration = configuration;
        _connection = new ConnectionFactory() {
            HostName = _configuration["RabbitMqHost"],
            Port = Int32.Parse(_configuration["RabbitMqPort"])
        }.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
    }
    public void EnviarPedidoParaEstoque(ReadPedidoDto readPedidoDto) {
        string mensagem = JsonSerializer.Serialize(readPedidoDto);
        var body = Encoding.UTF8.GetBytes(mensagem);

        _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);
    }
}