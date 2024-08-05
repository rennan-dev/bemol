namespace Desafio02.Modelos;

internal class Livro : Produto, IIdetificacao
{
    public string Isbn { get; set; }
    public int TotalDePaginas { get; set; }

    public override void VisualizaProduto(List<Produto> produtos) 
    {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Livros cadastrados:\n");
        foreach (Produto produto in produtos.OfType<Livro>())
        {
            Livro livro = (Livro)produto;
            Console.WriteLine($"Nome: {livro.Nome}");
            Console.WriteLine($"Descrição do livro: {livro.Descricao}");
            Console.WriteLine($"Preço unitário: {livro.PrecoUnitario:F2} R$");
            Console.WriteLine($"Quantidade no estoque: {livro.Quantidade}");
            Console.WriteLine($"ISBN: {livro.Isbn}");
            Console.WriteLine($"Quantidade de páginas: {livro.TotalDePaginas}\n");
            Console.WriteLine("----------------------------------------");
        }
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public override void AdicionaProduto(List<Produto> produtos)
    {
        Livro livro = new Livro();
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Cadastrar livro:\n");

        Console.Write("Digite o nome do livro: ");
        livro.Nome = Console.ReadLine()!;
        if(string.IsNullOrEmpty(livro.Nome))
        {
            Console.WriteLine("O nome do livro não pode ser nulo.");
        }else
        {
            Console.Write("Digite uma descrição para o livro: ");
            livro.Descricao = Console.ReadLine()!;

            Console.Write("Digite o preço do livro: ");
            if(int.TryParse(Console.ReadLine(), out int valor))
            {
                livro.PrecoUnitario = valor;
            }

            Console.Write("Digite a quantidade em estoque: ");
            if(int.TryParse(Console.ReadLine(), out int quantidade))
            {
                livro.Quantidade = quantidade;
            }

            Console.Write("Digite o ISBN: ");
            livro.Isbn = Console.ReadLine()!;

            Console.Write("Digite a quantidade de páginas: ");
            if (int.TryParse(Console.ReadLine(), out int quantidadeDePaginas))
            {
                livro.TotalDePaginas = quantidadeDePaginas;
            }

            produtos.Add(livro);
        }
    }

    public string Identificar(List<Produto> produtos, List<Cliente> clientes) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Procurar livro:\n");

        Console.Write("Digite o nome do livro que procura: ");
        string nome = Console.ReadLine()!;

        if(string.IsNullOrWhiteSpace(nome)) {
            return "Nome do livro não pode estar vazio.";
        }
        foreach(Produto produto in produtos.OfType<Livro>()) {
            Livro livro = (Livro)produto;
            if (livro.Nome.Equals(nome)){
                return $"Nome: {livro.Nome}\nISBN: {livro.Isbn}";
            }
        }
        
        return $"Livro não encontrado";
    }
}
