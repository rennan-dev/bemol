using System.Text.Json;
using Semana4_Rennan.Filtros;
using Semana4_Rennan.Modelos;

List<Produto> produtos = new();
List<Cliente> clientes = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("1 para adicionar produto");
    Console.WriteLine("2 para adicionar livro");
    Console.WriteLine("3 para adicionar eletrônico");
    Console.WriteLine("4 para visualizar produtos");
    Console.WriteLine("5 para visualizar livros");
    Console.WriteLine("6 para visualizar um eletrônico");
    Console.WriteLine("7 para visualizar produtos por nome");
    Console.WriteLine("8 para visualizar produtos por preço");
    Console.WriteLine("9 para adicionar um cliente");
    Console.WriteLine("10 para ver clientes");
    Console.WriteLine("11 para procurar um livro");
    Console.WriteLine("12 para procurar um cliente");
    Console.WriteLine("13 para solicitar uma consulta http");
    Console.WriteLine("14 para ordernar produtos de Fake Store por nome");
    Console.WriteLine("15 para ordernar produtos de Fake Store por preço");
    Console.WriteLine("0 para sair");

    Console.Write("Digite sua resposta: ");
    string input = Console.ReadLine()!;
    if (int.TryParse(input, out int aux))
    {
        switch (aux)
        {
            case 1: new Produto().AdicionaProduto(produtos); break;
            case 2: new Livro().AdicionaProduto(produtos); break;
            case 3: new Eletronico().AdicionaProduto(produtos); break;
            case 4: new Produto().VisualizaProduto(produtos); break;
            case 5: new Livro().VisualizaProduto(produtos); break;
            case 6: new Eletronico().VisualizaProduto(produtos); break;
            case 7: Produto.OrdenaProdutoNome(produtos); break;
            case 8: Produto.OrdenaProdutoPreco(produtos); break;
            case 9: new Cliente().AdicionaCliente(clientes); break;
            case 10: new Cliente().VisualizaClientes(clientes); break;
            case 11:
                Console.WriteLine(new Livro().Identificar(produtos, clientes));
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                Console.ReadKey(); break;
            case 12:
                Console.WriteLine(new Cliente().Identificar(produtos, clientes));
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                Console.ReadKey(); break;
            case 13:
                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        string resposta = await cliente.GetStringAsync("https://fakestoreapi.com/products");
                        var produtosFakeStore = JsonSerializer.Deserialize<List<FakeStore>>(resposta);
                        produtosFakeStore[10].ExibirDetalhesDoProduto();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Temos um erro: {ex.ToString()}");
                    }
                }
                break;
            case 14:
                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        string resposta = await cliente.GetStringAsync("https://fakestoreapi.com/products");
                        var produtosFakeStore = JsonSerializer.Deserialize<List<FakeStore>>(resposta);
                        LinqFilter.OrdernarPorNome(produtosFakeStore);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Temos um erro: {ex.ToString()}");
                    }
                }
                break;
            case 15:
                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        string resposta = await cliente.GetStringAsync("https://fakestoreapi.com/products");
                        var produtosFakeStore = JsonSerializer.Deserialize<List<FakeStore>>(resposta);
                        LinqFilter.OrdernarPorPreco(produtosFakeStore);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Temos um erro: {ex.ToString()}");
                    }
                }
                break;
            case 0: Console.WriteLine("Fiz o meu melhor, desculpa por fazer você ir embora..."); return;
            default: Console.WriteLine("Digite uma opção válida."); Thread.Sleep(2000); break;
        }
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        Thread.Sleep(2000);
    }
}