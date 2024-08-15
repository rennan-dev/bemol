using Comex.Interfaces;

namespace Comex.Modelos;
internal class Livro : Produto, IIdentificar {
    public string Isbn { get; set; }
    public int TotalDePaginas { get; set; }
    public Livro(string nome) : base(nome) {}

    public override string ToString() {
        return base.ToString() +
               $"Especificação do Livro:\n" +
               $"\tISBN: {Isbn}\n" +
               $"\tTotal de Páginas: {TotalDePaginas}\n\n";
    }

    public string Identificar() {
        return $"Livro: {Nome}\n" +
               $"ISBN: {Isbn}\n\n";
    }
}
