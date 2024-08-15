using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuAdicionarPedido : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tCriação do Pedido\n");
        int validando = -1;

        Console.Write("Digite o CPF do cliente que deseja fazer a compra: ");
        string cpf = Console.ReadLine()!;
        foreach(Cliente cliente in clientes) { 
            if(cliente.Cpf.Equals(cpf)) {

                Pedido pedido = new();
                pedido.cliente = cliente;
                pedido.Data = DateTime.Now;
                pedido.AdicionarItem(produtos);
                pedidos.Add(pedido);
                validando = 1; break;
            }
        }

        if(validando == -1) { Console.WriteLine("Cliente não encontrado..."); }

        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
