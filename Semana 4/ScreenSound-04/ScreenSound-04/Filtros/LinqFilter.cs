using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGeneros(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();
        foreach(var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var todosOsArtistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine($"Artista(s) do gênero {genero}:\n");
        foreach(var artista in todosOsArtistasPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasPorArtista(List<Musica> musicas, string artista)
    {
        var todasAsMusicasPorArtista = musicas.Where(musica => musica.Artista!.Equals(artista)).Distinct().ToList();
        Console.WriteLine($"Músicas de {artista}: ");
        foreach(var musica in todasAsMusicasPorArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano)
    {
        var musicasFiltrasPorAno = musicas.Where(musica => musica.Ano == ano).OrderBy(musicas => musicas.Nome).Select(musicas => musicas.Nome).Distinct().ToList();
        Console.WriteLine($"Músicas filtradas no ano de {ano}:\n");
        foreach(var musica in musicasFiltrasPorAno)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}
