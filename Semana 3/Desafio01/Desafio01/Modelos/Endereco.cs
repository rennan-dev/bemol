namespace Desafio01.Modelos;

class Endereco {
    public Endereco(string bairro, string rua, string complemento, string estado, string cidade, int numero) {
        Bairro = bairro;
        Rua = rua;
        Complemento = complemento;
        Estado = estado;
        Cidade = cidade;
        Numero = numero;
    }

    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public int Numero { get; set; }

    public void MostraEndereco() {
        Console.WriteLine($"Bairro: {Bairro}");
        Console.WriteLine($"Rua: {Rua}");
        Console.WriteLine($"Complemento: {Complemento}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Cidade: {Cidade}");
        Console.WriteLine($"Numero: {Numero}");
    }

}