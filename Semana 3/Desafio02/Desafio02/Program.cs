List<Produto> produtos = new();

while(true) {  
    Console.Clear();
    Console.WriteLine("1 para adicionar produto");
    Console.WriteLine("2 para visualizar produtos");
    Console.WriteLine("0 para sair");
    
    Console.Write("Digite sua resposta: ");
    string input = Console.ReadLine()!;
    if (int.TryParse(input, out int aux)) {
        switch (aux) {
            case 1: new Produto().AdicionaProduto(produtos); break;
            case 2: new Produto().VisualizaProduto(produtos); break;
            case 0: Console.WriteLine("Fiz o meu melhor, desculpa por fazer você ir embora..."); return;
            default: Console.WriteLine("Digite uma opção válida."); Thread.Sleep(2000); break;
        }
    }else {
        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        Thread.Sleep(2000);
    }
}