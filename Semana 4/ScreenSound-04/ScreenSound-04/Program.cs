using System.Text.Json;
using ScreenSound_04.Modelos;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient()) {
    try {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>> (resposta)!;
        //Console.WriteLine(resposta);
        //LinqOrder.ExibirListaDeArtistasOrdenadas(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasPorArtista(musicas, "Red Hot Chili Peppers");
        LinqFilter.FiltrarMusicasPorAno(musicas, 2012);
    }
    catch(Exception ex) {
        Console.WriteLine($"temos um problema: {ex.Message}");
    }
}