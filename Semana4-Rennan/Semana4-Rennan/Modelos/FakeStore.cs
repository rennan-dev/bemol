using System.Text.Json.Serialization;

namespace Semana4_Rennan.Modelos;

internal class FakeStore
{
    [JsonPropertyName("title")]
    public string Titulo { get; set; }

    [JsonPropertyName("price")]
    public double Preco { get; set; }

    [JsonPropertyName("description")]
    public string Descricao { get; set; }

    [JsonPropertyName("category")]
    public string Categoria { get; set; }

    public void ExibirDetalhesDoProduto() {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Consulta HPPT:\n");

        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Preço: {Preco}");
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Categoria: {Categoria}");

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
