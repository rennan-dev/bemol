using System.Text;
using System.Text.Json;
using Estoque.Dtos.Pedido;

namespace Estoque.PedidoHttpClient;

public class PedidoHttpClient : IPedidoHttpClient {
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public PedidoHttpClient(HttpClient client, IConfiguration configuration) {
        _client = client;
        _configuration = configuration;
    }
    public async Task UpdatePedido(int pedidoId, UpdatePedidoDto updatePedidoDto) {
        var url = $"{_configuration["PedidoService"]}/{pedidoId}";

        Console.WriteLine($"Requisição para: {url}"); //log para depuração

        var jsonContent = new StringContent(JsonSerializer.Serialize(updatePedidoDto), Encoding.UTF8, "application/json");

        var response = await _client.PutAsync(url, jsonContent);

        if(response.IsSuccessStatusCode) {
            Console.WriteLine($"Pedido {pedidoId} atualizado com sucesso.");
        } else {
            Console.WriteLine($"Erro ao atualizar pedido {pedidoId}. Status Code: {response.StatusCode}");
            var errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Detalhes do erro: {errorMessage}");
        }
    }
}