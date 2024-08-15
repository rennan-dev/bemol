using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuMostrarLivrosRegistrados : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tExibindo todos os livros registradas na nossa aplicação\n");

        foreach(Livro produto in produtos.OfType<Livro>()) {
            Livro livro = (Livro)produto;
            Console.WriteLine(livro.ToString());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
