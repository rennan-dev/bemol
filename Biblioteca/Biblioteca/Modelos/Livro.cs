namespace BibliotecaBemol.Modelos; 
internal class Livro {
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Isbn { get; set; }
    public DateTime DataPublicacao { get; set; }
    public bool EstaEmprestado { get; set; }

    public void Emprestar() {
        EstaEmprestado = true;
        Console.WriteLine("Livro Emprestado com Sucesso!");
        Console.Write("\nDigite alguma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public void Devolver() {
        EstaEmprestado = false;
        Console.WriteLine("Livro Devolvido com Sucesso!");
        Console.Write("\nDigite alguma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public string ExibirInformacoes() {
        return $"\nTítulo: {Titulo}\n" +
            $"Autor: {Autor}\n" +
            $"ISBN: {Isbn}\n" +
            $"Data de Publicação: {DataPublicacao.ToString("dd/MM/yyyy")}\n";
    }
}
