using Comex.Filtros;
using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuOrdenarPorTitulo : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tProdutos Ordenados por Nome\n");

        var produtosOrdenados = LinqFilter.FiltrarProdutoPorTitulo(produtos);
        foreach(var produto in produtosOrdenados) {
            Console.WriteLine(produto.ToString());
        }
        
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
