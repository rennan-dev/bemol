using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuAdicionarLivro : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tRegistro de Livro\n");

        Console.Write("Digite o nome do Livro que deseja registrar: ");
        string nome = Console.ReadLine()!;
        Livro produto = new(nome);

        Console.Write("Digite a descrição para o livro: ");
        produto.Descricao = Console.ReadLine()!;
        Console.Write("Digite o preço unitário do livro: ");
        produto.PrecoUnitario = Convert.ToDouble(Console.ReadLine());
        Console.Write("Digite a quantidade em estoque: ");
        produto.Quantidade = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o ISBN: ");
        produto.Isbn = Console.ReadLine()!;
        Console.Write("Digite a quantidade de páginas do livro: ");
        produto.TotalDePaginas = Convert.ToInt32(Console.ReadLine());

        produtos.Add(produto);
        Console.WriteLine($"O Livro {produto.Nome} foi registrado com sucesso!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
