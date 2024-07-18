//Produto prod1 = new Produto("Bolacha", "Alimentício", 3.5f, 100);
//Produto prod2 = new Produto("Macarrão", "Alimentício", 8.99f, 40);
//Produto prod3 = new Produto("Picanha", "Alimentício", 40f, 30);

//Console.Write("Digite o nome do 4° produto: ");
//string nomeProduto = Console.ReadLine()!;
//Produto prod4 = new Produto(nomeProduto, "Limpeza", 40f, 30);

//prod1.VisualizaProduto();
//prod2.VisualizaProduto();
//prod3.VisualizaProduto();
//prod4.VisualizaProduto();

List<Produto> produtos = new();

while(true) {
    Console.WriteLine("\n---------------------------------------");
    Console.WriteLine("1 para adicionar produto");
    Console.WriteLine("2 para visualizar produtos");
    Console.WriteLine("0 para sair");
    Console.Write("Digite sua resposta: ");
    int aux = Console.Read();

    switch(aux) {
        case 1: AdicionaProd(produtos); break;

        default: Console.WriteLine("Digite uma opção válida."); break;
    }
}

void AdicionaProd(List<Produto> prods) {
    string nomeProduto = Console.ReadLine()!;
    if(!string.IsNullOrWhiteSpace(nomeProduto)) {

    }
}