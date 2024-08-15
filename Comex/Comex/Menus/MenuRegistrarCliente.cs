using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuRegistrarCliente : Menu {

    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Cliente cliente = new();
        Endereco endereco = new();
        cliente.EnderecoCliente = endereco;

        Console.WriteLine("\tRegistro de cliente\n");

        Console.Write("Digite o nome do cliente: ");
        cliente.Nome = Console.ReadLine()!;
        Console.Write("Digite o CPF do cliente: ");
        cliente.Cpf = Console.ReadLine()!;
        Console.Write("Digite o email do cliente: ");
        cliente.Email = Console.ReadLine()!;
        Console.Write("Digite a profissão do cliente: ");
        cliente.Profissao = Console.ReadLine()!;
        Console.Write("Digite o telefone do cliente: ");
        cliente.Telefone = Console.ReadLine()!;

        Console.WriteLine("\n--- Endereço do Cliente ---");
        Console.Write("Digite a rua: ");
        endereco.Rua = Console.ReadLine()!;
        Console.Write("Digite o número: ");
        endereco.Numero = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o bairro: ");
        endereco.Bairro = Console.ReadLine()!;
        Console.Write("Digite a cidade: ");
        endereco.Cidade = Console.ReadLine()!;
        Console.Write("Digite o estado: ");
        endereco.Estado = Console.ReadLine()!;
        Console.Write("Digite o complemento: ");
        endereco.Complemento = Console.ReadLine()!;

        clientes.Add(cliente);
        Console.WriteLine($"\nO cliente {cliente.Nome} foi registrado com sucesso!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
