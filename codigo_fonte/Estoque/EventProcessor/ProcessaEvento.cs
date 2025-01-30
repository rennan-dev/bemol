using System.Text;
using System.Text.Json;
using AutoMapper;
using Estoque.Data;
using Estoque.Dtos;
using Estoque.Dtos.Pedido;
using Estoque.Models;
using Estoque.PedidoHttpClient;

namespace Estoque.EventProcessor;

public class ProcessaEvento : IProcessaEvento {

    private readonly IMapper _mapper;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IPedidoHttpClient _pedidoHttpClient;


    public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory, IPedidoHttpClient pedidoHttpClient) {
        _mapper = mapper;
        _scopeFactory = scopeFactory;
        _pedidoHttpClient = pedidoHttpClient;
    }

    public async Task ProcessaAsync(string mensagem) {
        using var scope = _scopeFactory.CreateScope();
        var estoqueRepository = scope.ServiceProvider.GetRequiredService<IEstoqueRepository>();
        var readPedidoDto = JsonSerializer.Deserialize<ReadPedidoDto>(mensagem);

        Console.WriteLine("Mensagem recebida: " + mensagem);

        if(readPedidoDto.Itens == null || !readPedidoDto.Itens.Any()) {
            Console.WriteLine("Nenhum item encontrado na mensagem");
            return;
        }

        Console.WriteLine("Itens recebidos: " + readPedidoDto.Itens.Count());

        var pedido = _mapper.Map<PedidoCliente>(readPedidoDto);

        //salva o pedido antes de qualquer alteração no estoque
        estoqueRepository.CreatePedido(pedido);
        estoqueRepository.SaveChanges();

        try {
            //cria uma lista auxiliar para armazenar as atualizações de estoque pendentes
            var atualizacoesEstoque = new List<(int ProdutoId, int NovaQuantidade)>();

            //verificar se há estoque suficiente para todos os itens
            foreach(var item in readPedidoDto.Itens) {
                var produto = estoqueRepository.GetProdutoById(item.ProductId);

                if(produto == null) {
                    throw new KeyNotFoundException($"Produto com ID {item.ProductId} não encontrado.");
                }

                if(produto.QuantidadeDisponivel < item.Quantidade) {
                    throw new InvalidOperationException($"Estoque insuficiente para o produto ID {item.ProductId}. Disponível: {produto.QuantidadeDisponivel}, Solicitado: {item.Quantidade}");
                }

                //adiciona a atualização à lista auxiliar(sem aplicar imediatamente)
                atualizacoesEstoque.Add((produto.ProductId, produto.QuantidadeDisponivel - item.Quantidade));
            }

            //se chegou até aqui, significa que todos os produtos têm estoque suficiente
            foreach(var (produtoId, novaQuantidade) in atualizacoesEstoque) {
                var updateDto = new UpdateProdutoDto { QuantidadeDisponivel = novaQuantidade };
                estoqueRepository.UpdateProduto(produtoId, updateDto);
            }

            var updatePedidoDto = new UpdatePedidoDto { Status = "Confirmado" };
            estoqueRepository.UpdatePedido(pedido.PedidoKey, updatePedidoDto);

            //salva todas as alterações
            estoqueRepository.SaveChanges();
            Console.WriteLine($"Pedido {pedido.PedidoKey} confirmado com sucesso.");

            await _pedidoHttpClient.UpdatePedido(pedido.PedidoKey, new UpdatePedidoDto { Status = "Confirmado" });

        
        }catch (Exception ex) {
            Console.WriteLine($"Erro ao processar pedido {pedido.PedidoKey}: {ex.Message}");

            //atualiza o status do pedido para "Cancelado"(sem alterar o estoque)
            var updatePedidoDto = new UpdatePedidoDto { Status = "Cancelado" };
            estoqueRepository.UpdatePedido(pedido.PedidoKey, updatePedidoDto);

            //salva a alteração de status
            estoqueRepository.SaveChanges();

            await _pedidoHttpClient.UpdatePedido(pedido.PedidoKey, new UpdatePedidoDto { Status = "Cancelado" });
        }
    }
}