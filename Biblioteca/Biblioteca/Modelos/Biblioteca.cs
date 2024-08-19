using BibliotecaBemol.Validations;

namespace BibliotecaBemol.Modelos; 
internal class Biblioteca {
    public List<Livro> livros { get; set; }
    public List<Usuario> usuarios { get; set; }

    public Biblioteca() {
        this.livros = new List<Livro>();
        this.usuarios = new List<Usuario>();
    }

    public void AdicionarLivro(Livro livro) {
        Console.Clear();
        Validation validar = new();
        Console.WriteLine("\tAdicionar Livro\n");

        livro.Titulo = validar.ValidaNomeLivro(livro.Titulo, livros);
        livro.Autor = validar.ValidaAutorLivro(livro.Autor);
        livro.Isbn = validar.ValidaIsbnLivro(livro.Isbn, livros);
        livro.DataPublicacao = DateTime.Now;
        livro.EstaEmprestado = false;
        livros.Add(livro);

        Console.WriteLine("Livro Adicionado com sucesso!");
        Console.Write("\nDigite algo para voltar ao menu...");
        Console.ReadKey();
    }

    public void RemoverLivro() {
        Console.Clear();
        Console.WriteLine("\nRemover Livro\n");
        
        Console.Write("Digite o nome do livro que deseja remover: ");
        string remover = Console.ReadLine()!;

        foreach(Livro livro in livros) {
            if(livro.Titulo.Equals(remover)) {
                if(livro.EstaEmprestado==true) {
                    Console.WriteLine("O livro não está na biblioteca para ser removido..."); break;
                } else {
                    livros.Remove(livro);
                    Console.WriteLine("Livro removido com sucesso"); break;
                }
            }
        }
        Console.Write("Aperte qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public void RegistrarUsuario(Usuario usuario) {
        Console.Clear();
        Validation validar = new();
        Console.WriteLine("\tAdicionar Usuário\n");

        usuario.Nome = validar.ValidaNomeUsuario(usuario.Nome, usuarios);
        usuario.Cpf = validar.ValidaCpfUsuario(usuario.Cpf, usuarios);
        usuarios.Add(usuario);

        Console.WriteLine("Usuário Adicionado com sucesso!");
        Console.Write("\nDigite algo para voltar ao menu...");
        Console.ReadKey();
    }

    public void ExibirLivrosDisponiveis() {
        Console.Clear();
        Console.WriteLine("Livros Disponíveis para emprestimo\n");

        foreach(Livro livro in livros) {
            if(!livro.EstaEmprestado) {
                Console.WriteLine(livro.ExibirInformacoes());
            }
        }

        Console.Write("\nDigite qualquer tecla para voltar ao menu inicial...");
        Console.ReadKey();
    }

    public void ExibirUsuariosCadastrados() {
        Console.Clear();
        Console.WriteLine("Usuários Cadastrados\n");

        foreach (Usuario usuario in usuarios) {
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"CPF: {usuario.Cpf}");
            Console.WriteLine($"Empréstimo atual: {usuario.LivrosEmprestados.Count}\n");
        }

        Console.Write("\nDigite qualquer tecla para voltar ao menu inicial...");
        Console.ReadKey();
    }
}
