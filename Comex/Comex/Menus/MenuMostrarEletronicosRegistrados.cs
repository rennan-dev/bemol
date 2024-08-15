using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuMostrarEletronicosRegistrados : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tExibindo todos os eletrônicos registradas na nossa aplicação\n");

        foreach(Eletronico produto in produtos.OfType<Eletronico>()) {
            Eletronico eletronico = (Eletronico)produto;
            Console.WriteLine(eletronico.ToString());
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
