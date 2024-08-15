namespace Comex.Modelos;
internal class Endereco
{
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Complemento { get; set; }
    public string Estado { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }

    public Endereco() { }

    public Endereco(string bairro, string cidade, string complemento, string estado, string rua, int numero) {
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Complemento = complemento;
        this.Estado = estado;
        this.Rua = rua;
        this.Numero = numero;

    }
}
