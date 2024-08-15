namespace Comex.Modelos; 
internal class Pedido {
    public Cliente cliente { get; set; }
    public DateTime Data { get; set; }
    public List<ItemDePedido> itens { get; set; }
    public double Total { get; set; }

    public Pedido() {
        this.itens = new List<ItemDePedido>();
    }
  
    public void AdicionarItem(List<Produto> produtos) {
        Console.Clear();
        Console.WriteLine("Adicionando itens ao pedido\n");
        int opcao;

        do{
            int validando = -1;

            Console.Write("Digite o nome do produto que deseja adicionar ao pedido: ");
            string nome = Console.ReadLine()!;
            foreach(Produto produto in produtos) {
                if(produto.Nome.Equals(nome)) {
                    Console.Write("Digite a quantidade que deseja adicionar ao pedido: ");
                    int quantidade;
                    while(!int.TryParse(Console.ReadLine(), out quantidade)) {
                        Console.WriteLine("Valor inválido. Digite um número inteiro válido para a quantidade:");
                    }

                    if(quantidade > produto.Quantidade) {
                        Console.WriteLine("Não possuímos estoque o suficiente para a sua compra, desculpe pelo inconveniente...");
                    }else {
                        ItemDePedido item = new ItemDePedido();
                        item.produto = produto;
                        item.Quantidade = quantidade;
                        item.PrecoUnitario = produto.PrecoUnitario;
                        itens.Add(item);
                        produto.Quantidade -= quantidade;
                        Total += item.Subtotal;

                        Console.WriteLine($"Produto: {produto.Nome} adicionado com sucesso!");
                    }

                    validando = 1;
                    break;
                }
            }

            if(validando == -1) { Console.WriteLine("Produto não encontrado..."); }

            Console.WriteLine("\nDeseja adicionar outro item ao pedido?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("0 - Não (Encerrar)");
            while(!int.TryParse(Console.ReadLine(), out opcao) || (opcao != 1 && opcao != 0)) {
                Console.WriteLine("Opção inválida. Digite '1' para continuar ou '0' para encerrar:");
            }
            Console.Clear(); 

        }while(opcao == 1);

        Console.WriteLine("Finalizando adição de itens...");
    }


    public List<string> ObterNomesDosProdutos() {
        return itens
                .Where(i => i.produto != null) 
                .Select(i => i.produto.Nome)
                .ToList();
    }
    
    public override string ToString() {
        var nomesDosProdutos = string.Join(", ", ObterNomesDosProdutos());
        return $"Cliente: {cliente.Nome}\n" +
                $"Data do Pedido: {Data}\n" +
                $"Itens: {nomesDosProdutos}\n" +
                $"Total: {Total:F2}R$\n";
    }
}
