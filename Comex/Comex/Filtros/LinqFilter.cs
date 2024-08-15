using Comex.Modelos;

namespace Comex.Filtros; 
internal class LinqFilter {
    public static List<Produto> FiltrarProdutoPorTitulo(List<Produto> produtos) {
        var todosOsProdutosPorTitulo = produtos.OrderBy(x => x.Nome).ToList();

        return todosOsProdutosPorTitulo;
    }

    public static List<Produto> FiltrarProdutoPorPreco(List<Produto> produtos) {
        var todosOsProdutosPorPreco = produtos.OrderBy(x => x.PrecoUnitario).ToList();

        return todosOsProdutosPorPreco;
    }

    public static List<Pedido> FiltrarPedidoPorNome(List<Pedido> pedidos) {
        var todosOsPedidosPorNome = pedidos.OrderBy(x => x.cliente.Nome).ToList();

        return todosOsPedidosPorNome;
    }
}
