namespace Desafio02.Modelos;

internal class Cliente : IIdetificacao {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public Endereco EnderecoCliente { get; set; }

    public void VisualizaClientes(List<Cliente> clientes) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Clientes cadastrados:\n");

        foreach(Cliente cliente in clientes) {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"CPF: {cliente.Cpf}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Profissão: {cliente.Profissao}");
            Console.WriteLine($"Telefone: {cliente.Telefone}");
            Console.WriteLine("\nInformações de Endereço:\n");
            Console.WriteLine($"Bairro: {cliente.EnderecoCliente.Bairro}");
            Console.WriteLine($"Rua: {cliente.EnderecoCliente.Rua}");
            Console.WriteLine($"Complemento: {cliente.EnderecoCliente.Complemento}");
            Console.WriteLine($"Estado: {cliente.EnderecoCliente.Estado}");
            Console.WriteLine($"Cidade: {cliente.EnderecoCliente.Cidade}");
            Console.WriteLine($"Número: {cliente.EnderecoCliente.Numero}\n");
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public void AdicionaCliente(List<Cliente> clientes) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Adicionar cliente:\n");

        Console.Write("Digite o nome do cliente: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine()!;

        Console.Write("Digite o e-mail do cliente: ");
        string email = Console.ReadLine()!;

        Console.Write("Digite a profissão do cliente: ");
        string profissao = Console.ReadLine()!;

        Console.Write("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine()!;

        Console.WriteLine("Digite o endereço do cliente:");
        Console.Write("Bairro: ");
        string bairro = Console.ReadLine()!;
        Console.Write("Rua: ");
        string rua = Console.ReadLine()!;
        Console.Write("Complemento: ");
        string complemento = Console.ReadLine()!;
        Console.Write("Estado: ");
        string estado = Console.ReadLine()!;
        Console.Write("Cidade: ");
        string cidade = Console.ReadLine()!;
        Console.Write("Número: ");
        if (!int.TryParse(Console.ReadLine(), out int numero)) {
            Console.WriteLine("Número inválido, será considerado 0.");
            numero = 0;
        }

        Endereco enderecoCliente = new Endereco {
            Bairro = bairro,
            Rua = rua,
            Complemento = complemento,
            Estado = estado,
            Cidade = cidade,
            Numero = numero
        };

        Cliente cliente = new Cliente {
            Nome = nome,
            Cpf = cpf,
            Email = email,
            Profissao = profissao,
            Telefone = telefone,
            EnderecoCliente = enderecoCliente
        };

        clientes.Add(cliente);

        Console.WriteLine("Cliente adicionado com sucesso.");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }



    public string Identificar(List<Produto> produtos, List<Cliente> clientes) {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Procurar cliente:\n");

        Console.Write("Digite o nome do cliente que procura: ");
        string nome = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(nome)) {
            return "Nome do cliente não pode estar vazio.";
        }
        foreach (Cliente cliente in clientes) {
            if (cliente.Nome.Equals(nome)) {
                return $"Nome: {cliente.Nome}\nCPF: {cliente.Cpf}";
            }
        }

        return $"Cliente não encontrado";
    }
}