using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuSair : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\nFiz o meu melhor, desculpa por fazer você ir...");
        Environment.Exit(0);
    }
}
