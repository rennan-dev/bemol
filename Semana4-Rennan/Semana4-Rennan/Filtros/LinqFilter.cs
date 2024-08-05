
using Semana4_Rennan.Modelos;

namespace Semana4_Rennan.Filtros;

internal class LinqFilter
{
    public static void OrdernarPorNome(List<FakeStore> fakeStore) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Ordern informações FakeStore por nome:\n");

        var produtosPorNome = fakeStore.OrderBy(fakeStore => fakeStore.Titulo).ToList();
        foreach(var produto in produtosPorNome) {
            Console.WriteLine($"Título: {produto.Titulo}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Categoria: {produto.Categoria}\n");
        }

        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public static void OrdernarPorPreco(List<FakeStore> fakeStore)
    {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Ordern informações FakeStore por preço:\n");

        var produtosPorPreco = fakeStore.OrderBy(fakeStore => fakeStore.Preco).ToList();
        foreach (var produto in produtosPorPreco)
        {
            Console.WriteLine($"Título: {produto.Titulo}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
            Console.WriteLine($"Categoria: {produto.Categoria}\n");
        }

        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
