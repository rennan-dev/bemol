namespace Comex.Modelos;
internal class Produto {
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public Produto(string nome) {
        Nome = nome;
    }

    public override string ToString() {
        return $"\nProduto: {Nome}\n" +
               $"Descrição: {Descricao}\n" +
               $"Preço da Unidade: {PrecoUnitario:F2}R$\n" +
               $"Quantidade em Estoque: {Quantidade}\n";
    }
}
