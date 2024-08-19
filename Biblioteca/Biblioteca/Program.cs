using BibliotecaBemol.Modelos;

Biblioteca biblioteca = new();

void ExibirOpcoesMenu() {
    while(true) {
        Console.Clear();
        Console.WriteLine("Digite 1 para adicionar um livro");
        Console.WriteLine("Digite 2 para ver todos os livros cadastrados");
        Console.WriteLine("Digite 3 para adicionar um usuário");
        Console.WriteLine("Digite 4 para ver todos os usuários");
        Console.WriteLine("Digite 5 para remover um livro");
        Console.WriteLine("Digite 6 para emprestar um livro");
        Console.WriteLine("Digite 7 para devolver um livro");
        Console.WriteLine("Digite 8 para ver o histórico de empréstimos");
        Console.WriteLine("Digite -1 para sair da aplicação");
        Console.Write("\nDigite a sua resposta: ");
        string resposta = Console.ReadLine()!;

        if(int.TryParse(resposta, out int respostaNumerica)) {
            switch(respostaNumerica) {
                case -1:
                    Console.Clear();
                    Console.WriteLine("\nFiz o meu melhor, desculpa por fazer você ir...");
                    Environment.Exit(0); break;
                case 1: 
                    Livro livro = new();
                    biblioteca.AdicionarLivro(livro); break;
                case 2:
                    biblioteca.ExibirLivrosDisponiveis(); break;
                case 3:
                    Usuario usuario = new();
                    biblioteca.RegistrarUsuario(usuario); break;
                case 4:
                    biblioteca.ExibirUsuariosCadastrados(); break;
                case 5:
                    biblioteca.RemoverLivro(); break;
                case 6:
                    Usuario usuario1 = new();
                    usuario1.EmprestarLivro(biblioteca.usuarios, biblioteca.livros); break;
                case 7:
                    Usuario usuario2 = new();
                    usuario2.DevolverLivro(biblioteca.usuarios); break;
                case 8:
                    Usuario usuario3 = new();
                    usuario3.ExibirHistoricoEmprestimos(biblioteca.usuarios); break;
                default:
                    Console.Write("Escolha uma opção válida...");
                    Console.ReadKey(); break;
            }
        }
    }
}

ExibirOpcoesMenu();