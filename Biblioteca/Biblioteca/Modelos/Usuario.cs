using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaBemol.Modelos; 
internal class Usuario {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public List<Livro> LivrosEmprestados { get; set; }

    public List<string> Historico { get; set; }

    public Usuario() { 
        LivrosEmprestados = new List<Livro>();
        this.Historico = new List<string>();
    }

    public void EmprestarLivro(List<Usuario> usuarios, List<Livro> livros) {
        Console.Clear();
        Console.WriteLine("\nEmprestar Livro\n");

        Console.Write("Digite o nome do usuário que irá emprestar: ");
        string usuario = Console.ReadLine()!.Trim();
        foreach(Usuario usuarioRegistrado in usuarios) {
            if(usuarioRegistrado.Nome.Equals(usuario)) {

                Console.Write("Digite o nome do livro que deseja emprestar: ");
                string livro = Console.ReadLine()!.Trim();
                foreach(Livro livroRegistrado in livros) {
                    if(livroRegistrado.Titulo.Equals(livro)) {

                        if(usuarioRegistrado.LivrosEmprestados.Count >= 3) {
                            Console.WriteLine("Usuário está com 3 livros emprestados, cancelando empréstimo...");
                            Console.ReadKey(); return;
                        }

                        if(livroRegistrado.EstaEmprestado) {
                            Console.WriteLine("Livro já está emprestado, cancelando empréstimo...");
                            Console.ReadKey(); return;
                        }
                        
                        usuarioRegistrado.LivrosEmprestados.Add(livroRegistrado);
                        usuarioRegistrado.RegistrarEmprestimo(usuarioRegistrado, livroRegistrado);
                        livroRegistrado.Emprestar();
                        return;
                    }
                }
            }
        }
        Console.Write("\nDigite algo para voltar ao menu...");
        Console.ReadKey();
    }

    public void DevolverLivro(List<Usuario> usuarios) {
        Console.Clear();
        Console.WriteLine("\tDevolver Livro\n");

        Console.Write("Digite o nome do usuário que irá devolver: ");
        string usuario = Console.ReadLine()!.Trim();
        foreach (Usuario usuarioRegistrado in usuarios) {
            if (usuarioRegistrado.Nome.Equals(usuario)) {

                Console.Write("Digite o nome do livro que irá ser devolvido: ");
                string livro = Console.ReadLine()!.Trim();
                foreach (Livro livroRegistrado in usuarioRegistrado.LivrosEmprestados) {
                    if (livroRegistrado.Titulo.Equals(livro)) {

                        usuarioRegistrado.RegistrarDevolucao(usuarioRegistrado, livroRegistrado);
                        usuarioRegistrado.LivrosEmprestados.Remove(livroRegistrado);
                        livroRegistrado.Devolver();
                        return;
                    }
                }
            }
        }
        Console.Write("\nDigite algo para voltar ao menu...");
        Console.ReadKey();
    }

    public void ExibirHistoricoEmprestimos(List<Usuario> usuarios) {
        int aux = 0;
        Console.Clear();
        Console.WriteLine("\tHistórico de Empréstimo\n");

        Console.Write("Digite o nome do usuário para fazer a consulta: ");
        string usuario = Console.ReadLine()!.Trim();

        foreach(Usuario usuarioRegistrado in usuarios) {
            if(usuarioRegistrado.Nome.Equals(usuario)) {
                foreach(string historico in usuarioRegistrado.Historico) {
                    Console.WriteLine(historico);
                }
                if(usuarioRegistrado.Historico.Count()==0) {
                    Console.WriteLine("Usuário não possui histórico\n");
                }
                break;
            }
        }

        Console.Write("\nDigite algo para voltar ao menu...");
        Console.ReadKey();
    }

    public void RegistrarEmprestimo(Usuario usuario, Livro livro) {
        DateTime date = DateTime.Now;
        string historico = $"Usuário: {usuario.Nome}, " +
                          $"emprestou o livro: {livro.Titulo}, " +
                          $"No dia {date}\n";
        usuario.Historico.Add(historico);
    }

    public void RegistrarDevolucao(Usuario usuario, Livro livro) {
        DateTime date = DateTime.Now;
        string historico = $"Usuário: {usuario.Nome}, " +
                          $"devolveu o livro: {livro.Titulo}, " +
                          $"No dia {date}\n";
        usuario.Historico.Add(historico);
    }
}
