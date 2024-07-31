using System.Text.Json.Serialization;

namespace ScreenSound_04.Modelos;

internal class Filme
{
    [JsonPropertyName("title")]
    public string Titulo { get; set; }
    [JsonPropertyName("year")]
    public string Ano { get; set; }
    [JsonPropertyName("crew")]
    public string Elenco { get; set; }

    public void MostrarFilme()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine($"Elenco: {Elenco}\n");
    }
}
