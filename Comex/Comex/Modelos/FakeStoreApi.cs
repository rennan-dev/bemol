using System.Text.Json.Serialization;

namespace Comex.Modelos;

internal class FakeStoreApi {

    [JsonPropertyName("title")]
    public string Titulo { get; set; }

    [JsonPropertyName("price")]
    public double Preco { get; set; }

    [JsonPropertyName("description")]
    public string Descricao { get; set; }

    [JsonPropertyName("category")]
    public string Categoria { get; set; }

    public void ExibirProdutos(List<FakeStoreApi> produtos) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Consulta HTTP - Produtos da FakeStoreAPI:\n");

        foreach(FakeStoreApi produto in produtos) {
            Console.WriteLine($"Título: {produto.Titulo}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Categoria: {produto.Categoria}");
            Console.WriteLine("----------------------------------------");
        }
    }
}