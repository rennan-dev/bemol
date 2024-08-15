using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuMostrarClientesRegistrados : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tExibindo todos os clientes registradas na nossa aplicação\n");

        foreach(Cliente cliente in clientes) {
            Console.WriteLine(cliente.ToString());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
