﻿using Comex.Modelos;

namespace Comex.Menus; 
internal class MenuAdicionarEletronico : Menu {
    public override void Executar(List<Produto> produtos, List<Cliente> clientes) {
        base.Executar(produtos, clientes);
        Console.WriteLine("\tRegistro de Eletrônico\n");

        Console.Write("Digite o nome do Eletrônico que deseja registrar: ");
        string nome = Console.ReadLine()!;
        Eletronico produto = new(nome);

        Console.Write("Digite a descrição para o eletrônico: ");
        produto.Descricao = Console.ReadLine()!;
        Console.Write("Digite o preço unitário do eletrônico: ");
        produto.PrecoUnitario = Convert.ToDouble(Console.ReadLine());
        Console.Write("Digite a quantidade em estoque: ");
        produto.Quantidade = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a voltagem do eletrônico: ");
        produto.Voltagem = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a potência do eletrônico: ");
        produto.Potencia = Convert.ToInt32(Console.ReadLine());

        produtos.Add(produto);
        Console.WriteLine($"O eletrônico {produto.Nome} foi registrado com sucesso!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
