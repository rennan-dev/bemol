using Comex.Filtros;
using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuMostrarPedidos : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tPedidos Ordenados por Nome do Cliente\n");

        var clientesOrdenados = LinqFilter.FiltrarPedidoPorNome(pedidos);
        foreach(var pedido in clientesOrdenados) {
            Console.WriteLine(pedido.ToString());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
