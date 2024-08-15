using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuAdicionarProduto : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tRegistro de produto\n");

        Console.Write("Digite o nome do produto que deseja registrar: ");
        string nome = Console.ReadLine()!;
        Produto produto = new(nome);

        Console.Write("Digite a descrição para o produto: ");
        produto.Descricao = Console.ReadLine()!;
        Console.Write("Digite o preço unitário do produto: ");
        produto.PrecoUnitario = Convert.ToDouble(Console.ReadLine());
        Console.Write("Digite a quantidade em estoque: ");
        produto.Quantidade = Convert.ToInt32(Console.ReadLine());

        produtos.Add(produto);
        Console.WriteLine($"O produto {produto.Nome} foi registrado com sucesso!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
