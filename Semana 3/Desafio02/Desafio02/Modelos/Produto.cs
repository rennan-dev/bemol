namespace Desafio02.Modelos;

class Produto {
    public string Nome;
    public string Descricao;
    public float PrecoUnitario;
    public int Quantidade;

    

    public virtual void VisualizaProduto(List<Produto> produtos) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Produtos cadastrados:\n");
        foreach(Produto produto in produtos) {
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Descrição do produto: {produto.Descricao}");
            Console.WriteLine($"Preço unitário: {produto.PrecoUnitario:F2} R$");
            Console.WriteLine($"Quantidade no estoque: {produto.Quantidade}\n");
            Console.WriteLine("----------------------------------------");
        }
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public virtual void AdicionaProduto(List<Produto> produtos) {
        Produto produto = new Produto();
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Adicionar produto:\n");

        Console.Write("Digite o nome do produto: ");
        produto.Nome = Console.ReadLine()!;
        if(string.IsNullOrWhiteSpace(produto.Nome)) {
            Console.WriteLine("O nome do produto não pode ser nulo.");
        }else {

            Console.Write("Digite uma descrição para o produto: ");
            produto.Descricao = Console.ReadLine()!;

            Console.Write("Digite o preço do produto: ");
            if (float.TryParse(Console.ReadLine(), out float precoUnitario)) {
                produto.PrecoUnitario = precoUnitario;
            }

            Console.Write("Digite a quantidade no estoque: ");
            if (int.TryParse(Console.ReadLine(), out int quantidade)) {
                produto.Quantidade = quantidade;
            }

            produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso.");
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}