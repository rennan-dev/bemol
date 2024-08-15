using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuMostrarProdutosRegistrados : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tExibindo todos os produtos registradas na nossa aplicação\n");

        foreach(Produto produto in produtos) {
            Console.WriteLine(produto.ToString());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
