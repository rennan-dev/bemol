using Comex.Interfaces;

namespace Comex.Modelos;
internal class Cliente : IIdentificar {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public Endereco EnderecoCliente { get; set; }

    public Cliente() { }

    public Cliente(string nome, string cpf, string email, string profissao, string telefone, Endereco endereco) {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Email = email;
        this.Profissao = profissao;
        this.Telefone = telefone;
        this.EnderecoCliente = endereco;
    }
    public override string ToString() {
        return $"Nome: {Nome}\n" +
               $"CPF: {Cpf}\n" +
               $"Email: {Email}\n" +
               $"Profissão: {Profissao}\n" +
               $"Telefone: {Telefone}\n" +
               $"Endereço:\n" +
               $"  Rua: {EnderecoCliente.Rua}, Nº: {EnderecoCliente.Numero}\n" +
               $"  Bairro: {EnderecoCliente.Bairro}\n" +
               $"  Cidade: {EnderecoCliente.Cidade}\n" +
               $"  Estado: {EnderecoCliente.Estado}\n" +
               $"  Complemento: {EnderecoCliente.Complemento}\n\n";
    }

    public string Identificar() {
        return $"Cliente: {Nome}\n" +
               $"CPF: {Cpf}\n\n";
    }
}
