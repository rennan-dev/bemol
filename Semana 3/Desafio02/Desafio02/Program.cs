using Desafio02.Modelos;

List<Produto> produtos = new();
List<Cliente> clientes = new();

while(true) {  
    Console.Clear();
    Console.WriteLine("1 para adicionar produto");
    Console.WriteLine("2 para adicionar livro");
    Console.WriteLine("3 para adicionar eletrônico");
    Console.WriteLine("4 para visualizar produtos");
    Console.WriteLine("5 para visualizar livros");
    Console.WriteLine("6 para visualizar um eletrônico");
    Console.WriteLine("7 para adicionar um cliente");
    Console.WriteLine("8 para ver clientes");
    Console.WriteLine("9 para procurar um livro");
    Console.WriteLine("10 para procurar um cliente");
    Console.WriteLine("0 para sair");
    
    Console.Write("Digite sua resposta: ");
    string input = Console.ReadLine()!;
    if (int.TryParse(input, out int aux)) {
        switch (aux) {
            case 1: new Produto().AdicionaProduto(produtos); break;
            case 2: new Livro().AdicionaProduto(produtos); break;
            case 3: new Eletronico().AdicionaProduto(produtos); break;
            case 4: new Produto().VisualizaProduto(produtos); break;
            case 5: new Livro().VisualizaProduto(produtos); break;
            case 6: new Eletronico().VisualizaProduto(produtos); break;
            case 7: new Cliente().AdicionaCliente(clientes); break;
            case 8: new Cliente().VisualizaClientes(clientes); break;
            case 9:
                Console.WriteLine(new Livro().Identificar(produtos, clientes));
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                Console.ReadKey(); break;
            case 10:
                Console.WriteLine(new Cliente().Identificar(produtos, clientes));
                Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                Console.ReadKey(); break;
            case 0: Console.WriteLine("Fiz o meu melhor, desculpa por fazer você ir embora..."); return;
            default: Console.WriteLine("Digite uma opção válida."); Thread.Sleep(2000); break;
        }
    }else {
        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        Thread.Sleep(2000);
    }
}