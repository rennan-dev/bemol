namespace Desafio02.Modelos;

internal class Eletronico : Produto {
    public int Voltagem { get; set; }
    public int Potencia { get; set; }

    public override void VisualizaProduto(List<Produto> produtos) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Eletrônicos cadastrados:\n");
        foreach(Produto produto in produtos.OfType<Eletronico>()) {
            Eletronico eletronico = (Eletronico)produto;
            Console.WriteLine($"Nome: {eletronico.Nome}");
            Console.WriteLine($"Descrição do livro: {eletronico.Descricao}");
            Console.WriteLine($"Preço unitário: {eletronico.PrecoUnitario:F2} R$");
            Console.WriteLine($"Quantidade no estoque: {eletronico.Quantidade}");
            Console.WriteLine($"Voltagem: {eletronico.Voltagem}");
            Console.WriteLine($"Potência: {eletronico.Potencia}\n");
            Console.WriteLine("----------------------------------------");
        }
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public override void AdicionaProduto(List<Produto> produtos) {
        Eletronico eletronico = new Eletronico();
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Cadastrar eletrônico:\n");

        Console.Write("Digite o nome do eletrônico: ");
        eletronico.Nome = Console.ReadLine()!;
        if(string.IsNullOrEmpty(eletronico.Nome)) {
            Console.WriteLine("O nome do eletrônico não pode ser nulo.");
        }else {
            Console.Write("Digite uma descrição para o eletrônico: ");
            eletronico.Descricao = Console.ReadLine()!;

            Console.Write("Digite o preço do eletrônico: ");
            if(int.TryParse(Console.ReadLine(), out int valor)) {
                eletronico.PrecoUnitario = valor;
            }

            Console.Write("Digite a quantidade em estoque: ");
            if(int.TryParse(Console.ReadLine(), out int quantidade)) {
                eletronico.Quantidade = quantidade;
            }

            Console.Write("Digite a voltagem: ");
            if(int.TryParse(Console.ReadLine(), out int voltagem)) {
                eletronico.Voltagem = voltagem;
            }

            Console.Write("Digite a potência: ");
            if(int.TryParse(Console.ReadLine(), out int potencia)) {
                eletronico.Potencia = potencia;
            }

            produtos.Add(eletronico);
        }
    }
}
