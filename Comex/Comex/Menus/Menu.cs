using Comex.Modelos;

namespace Comex.Menus; 
internal class Menu {
    public virtual void Executar(List<Produto> produtos, List<Cliente> clientes) {
        Console.Clear();
    }

    public virtual void Executar(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos) {
        Console.Clear();
    }
}
