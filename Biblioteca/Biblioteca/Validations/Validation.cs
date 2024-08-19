using BibliotecaBemol.Modelos;
using System.Text.RegularExpressions;

namespace BibliotecaBemol.Validations; 
internal class Validation {
    /*  START Validação Livro  */
    public string ValidaNomeLivro(string nome, List<Livro> livros) {
        Console.Write("Digite o nome do livro: ");
        nome = Console.ReadLine()!.Trim();
        if(string.IsNullOrWhiteSpace(nome)) {
            Console.Write("O nome do livro não pode conter apenas espaços em branco...");
            Console.ReadKey();
            Console.Clear();
            ValidaNomeLivro(nome, livros);
        }

        foreach(Livro livro in livros) {
            if(livro.Titulo.Equals(nome)) {
                Console.Write("Título já existe, tente outro...");
                Console.ReadKey();
                Console.Clear();
                ValidaNomeLivro(nome, livros);
            }
        }
        return nome;
    }

    public string ValidaAutorLivro(string autor) {
        Console.Write("Digite o nome do autor: ");
        autor = Console.ReadLine()!.Trim(); 

        if(string.IsNullOrWhiteSpace(autor)) {
            Console.Write("O nome do autor não pode conter apenas espaços em branco...");
            Console.ReadKey();
            Console.Clear();
            ValidaAutorLivro(autor);
        }
        if(!Regex.IsMatch(autor, @"^[a-zA-Z\s]+$")) {
            Console.Write("O nome do autor pode conter apenas letras e espaços...");
            Console.ReadKey();
            Console.Clear();
            ValidaAutorLivro(autor);
        }

        return autor;
    }

    public string ValidaIsbnLivro(string isbn, List<Livro> livros) {
        Console.Write("Digite o nome do ISBN: ");
        isbn = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(isbn)) {
            Console.Write("O ISBN do livro não pode conter apenas espaços em branco...");
            Console.ReadKey();
            Console.Clear();
            ValidaIsbnLivro(isbn, livros);
        }

        foreach(Livro livro in livros) {
            if(livro.Isbn.Equals(isbn)) {
                Console.Write("ISBN já existe, tente outro...");
                Console.ReadKey();
                Console.Clear();
                ValidaIsbnLivro(isbn, livros);
            }
        }
        return isbn;
    }
    /*  END Validação do Livro  */

    /*  START Validação Usuário */
    public string ValidaNomeUsuario(string nome, List<Usuario> usuarios) {
        Console.Write("Digite o nome do usuário: ");
        nome = Console.ReadLine()!.Trim();
        if (string.IsNullOrWhiteSpace(nome)) {
            Console.Write("O nome do usuário não pode conter apenas espaços em branco...");
            Console.ReadKey();
            Console.Clear();
            ValidaNomeUsuario(nome, usuarios);
        }

        if (!Regex.IsMatch(nome, @"^[a-zA-Z\s]+$")) {
            Console.Write("O nome do usuario pode conter apenas letras e espaços...");
            Console.ReadKey();
            Console.Clear();
            ValidaNomeUsuario(nome, usuarios);
        }

        foreach (Usuario usuario in usuarios) {
            if(usuario.Nome.Equals(nome)) {
                Console.Write("Usuário já existe, tente outro...");
                Console.ReadKey();
                Console.Clear();
                ValidaNomeUsuario(nome, usuarios);
            }
        }
        return nome;
    }

    public string ValidaCpfUsuario(string cpf, List<Usuario> usuarios) {
        Console.Write("Digite o CPF do usuário: ");
        cpf = Console.ReadLine()!.Trim();

        if(string.IsNullOrWhiteSpace(cpf)) {
            Console.Write("O CPF do usuário não pode conter apenas espaços em branco...");
            Console.ReadKey();
            Console.Clear();
            ValidaCpfUsuario(cpf, usuarios);
        }

        foreach (Usuario usuario in usuarios) {
            if(usuario.Cpf.Equals(cpf)) {
                Console.Write("CPF já existe, tente outro...");
                Console.ReadKey();
                Console.Clear();
                ValidaCpfUsuario(cpf, usuarios);
            }
        }
        return cpf;
    }
    /*  END Validação Usuário   */
}
