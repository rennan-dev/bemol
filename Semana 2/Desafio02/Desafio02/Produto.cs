class Produto {
    public string Nome;
    public string Descricao;
    public float PrecoUnitario;
    public int Quantidade;

    public Produto(string nome, string descricao, float precoUnitario, int quantidade) {
        Nome = nome;
        Descricao = descricao;
        PrecoUnitario = precoUnitario;
        Quantidade = quantidade;
    }

    public void VisualizaProduto() {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Descrição do produto: {Descricao}");
        Console.WriteLine($"Preço unitário: {PrecoUnitario:F2} R$");
        Console.WriteLine($"Quantidade no estoque: {Quantidade}\n");    
        Console.WriteLine("----------------------------------------");
    }
}