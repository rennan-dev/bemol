using Comex.Menus;
using Comex.Modelos;

string boasVindas = "\r\n\t█▄▄ █▀█ ▄▀█ █▀   █░█ █ █▄░█ █▀▄ ▄▀█ █▀ █\r\n\t█▄█ █▄█ █▀█ ▄█   ▀▄▀ █ █░▀█ █▄▀ █▀█ ▄█ ▄";

List<Produto> produtos = new();
List<Cliente> clientes = new();
List<Pedido> pedidos = new();

#region Adicionando produtos
Produto produto1 = new("Bolacha");
produto1.Descricao = "Bolacha recheada de chocolate";
produto1.PrecoUnitario = 3.5;
produto1.Quantidade = 30;

Produto produto2 = new("Suco");
produto2.Descricao = "Suco de laranja";
produto2.PrecoUnitario = 5;
produto2.Quantidade = 20;

produtos.Add(produto1);
produtos.Add(produto2);

#endregion
#region Adicionando clientes
Endereco endereco1 = new("Colônia", "Itacoatiara", "Casa de dois andares", "Amazonas", "Fileto Pires", 1263);
Cliente cliente1 = new("Rennan", "111", "rennan@gmail.com", "Dev", "92991660915", endereco1);
Cliente cliente2 = new("João", "222", "joao@gmail.com", "Marinheiro", "92991898389", endereco1);
clientes.Add(cliente1);
clientes.Add(cliente2);
#endregion


Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuAdicionarProduto());
opcoes.Add(2, new MenuMostrarProdutosRegistrados());
opcoes.Add(3, new MenuRegistrarCliente());
opcoes.Add(4, new MenuMostrarClientesRegistrados());
opcoes.Add(5, new MenuAdicionarEletronico());
opcoes.Add(6, new MenuMostrarEletronicosRegistrados());
opcoes.Add(7, new MenuAdicionarLivro());
opcoes.Add(8, new MenuMostrarLivrosRegistrados());
opcoes.Add(9, new MenuIdentificarCliente());
opcoes.Add(10, new MenuIdentificarLivro());
opcoes.Add(11, new MenuOrdenarPorTitulo());
opcoes.Add(12, new MenuOrdenarPorPreco());
opcoes.Add(13, new MenuConsultaExterna());
opcoes.Add(14, new MenuAdicionarPedido());
opcoes.Add(15, new MenuMostrarPedidos());
opcoes.Add(-1, new MenuSair());

void ExibirOpcoesDoMenu() {

    while(true) {
        Console.Clear();
        Console.WriteLine(boasVindas);
        Console.WriteLine("\nDigite 1 para registrar um produto");
        Console.WriteLine("Digite 2 para mostrar todos os produtos");
        Console.WriteLine("Digite 3 para registrar um cliente");
        Console.WriteLine("Digite 4 para visualizar todos os clientes");
        Console.WriteLine("Digite 5 para registrar um eletrônico");
        Console.WriteLine("Digite 6 para visualizar todos os eletrônicos");
        Console.WriteLine("Digite 7 para registrar um livro");
        Console.WriteLine("Digite 8 para visualizar todos os livros");
        Console.WriteLine("Digite 9 para identificar todos os clientes");
        Console.WriteLine("Digite 10 para identificar todos os livros");
        Console.WriteLine("Digite 11 para ordenar os produtos por título");
        Console.WriteLine("Digite 12 para ordenar os produtos por preço");
        Console.WriteLine("Digite 13 para fazer uma consulta externa para FakeStoreAPI");
        Console.WriteLine("Digite 14 para adicionar um pedido");
        Console.WriteLine("Digite 15 para visualizar todos os pedidos");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if(int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica)) {
            if(opcoes.ContainsKey(opcaoEscolhidaNumerica)) {
                Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];

                if(opcaoEscolhidaNumerica == 13) {
                    var consultaExternaMenu = (MenuConsultaExterna)menuASerExibido;
                    consultaExternaMenu.ConsultaExternaAsync().Wait();
                
                }else if (opcaoEscolhidaNumerica == 14 || opcaoEscolhidaNumerica == 15) {
                    menuASerExibido.Executar(produtos, clientes, pedidos);
                
                }else {
                    menuASerExibido.Executar(produtos, clientes);
                }

                if(opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
            }else {
                Console.WriteLine("Opção inválida...");
            }
        }
    }
}

ExibirOpcoesDoMenu();