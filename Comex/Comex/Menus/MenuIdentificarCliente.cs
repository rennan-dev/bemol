using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuIdentificarCliente : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tIdentificando todos os clientes registradas na nossa aplicação\n");

        foreach(Cliente cliente in clientes) {
            Console.WriteLine(cliente.Identificar());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
