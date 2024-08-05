using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace Desafio01.Modelos;

class Cliente {
    public Cliente(string nome, string cpf, string email, string profissao, string telefone, Endereco enderecoCliente) {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Profissao = profissao;
        Telefone = telefone;
        EnderecoCliente = enderecoCliente;
    }

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public Endereco EnderecoCliente { get; set; }

    public void MostraInformacoes() {
        Console.WriteLine("\n---------------------------------------------------");
        Console.WriteLine("Informações pessoais:\n");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {Cpf}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Profissao: {Profissao}");
        Console.WriteLine($"Telefone: {Telefone}");
        Console.WriteLine("\nInformações de Endereço:\n");
        Console.WriteLine($"Bairro: {EnderecoCliente.Bairro}");
        Console.WriteLine($"Rua: {EnderecoCliente.Rua}");
        Console.WriteLine($"Complemento: {EnderecoCliente.Complemento}");
        Console.WriteLine($"Estado: {EnderecoCliente.Estado}");
        Console.WriteLine($"Cidade: {EnderecoCliente.Cidade}");
        Console.WriteLine($"Numero: {EnderecoCliente.Numero}");
        Console.WriteLine("---------------------------------------------------");
    }
}