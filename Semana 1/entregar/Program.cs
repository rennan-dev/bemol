using System;
using System.Collections.Generic;

class Program {
    static List<string> produtos = new List<string>();
    
    static void Main() {
        menu();
    }
    
    static void menu() {
        string resposta;
        int respostaEscolhida;
        
        do {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Adicionar um produto");
            Console.WriteLine("2 - Listar todos os produtos cadastrados");
            Console.WriteLine("0 - Sair da aplicação");
            Console.Write("Resposta: ");
            resposta = Console.ReadLine();
            respostaEscolhida = int.Parse(resposta);
            
            switch(respostaEscolhida) {
                case 1: adicionaProduto(); break;
                case 2: listaProdutos(); break;
                case 0: Console.WriteLine("Fiz o meu melhor, adeus..."); break;
                default: Console.WriteLine("Selecione uma opção válida."); break;
            }
        }while(respostaEscolhida!=0);
    }
    
    static void adicionaProduto() {
        Console.Write("\nDigite o nome do produto: ");
        string nome = Console.ReadLine();
        produtos.Add(nome);
        Console.WriteLine($"Produto {nome} cadastrado");
    }
    
    static void listaProdutos() {
        Console.WriteLine("\nProdutos cadastrados:");
        foreach(string produto in produtos) {
            Console.WriteLine($"produto: {produto}");
        }
    }
}