using Estoque.Dtos;
using Estoque.Dtos.Pedido;
using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data;

public class EstoqueRepository : IEstoqueRepository {

    private readonly EstoqueContext _context;
    public EstoqueRepository(EstoqueContext context) {
        _context = context;
    }

    public void SaveChanges() {
        _context.SaveChanges();
    }

    public void CreateProduto(Produto produto) {
        if(produto==null) {
            throw new ArgumentNullException(nameof(produto));
        }
        _context.Produtos.Add(produto);
    }

    public void UpdateProduto(int id, UpdateProdutoDto updateProdutoDto) {
        var produtoExiste = _context.Produtos.FirstOrDefault(produto=>produto.ProductId == id);

        if(produtoExiste==null) {
            throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
        }

        produtoExiste.QuantidadeDisponivel = updateProdutoDto.QuantidadeDisponivel;
        _context.Produtos.Update(produtoExiste);
    }

    public void UpdatePedido(int id, UpdatePedidoDto updatePedidoDto) {
        var pedidoExiste = _context.Pedidos.FirstOrDefault(pedido=>pedido.PedidoKey == id);

        if(pedidoExiste==null) {
            throw new KeyNotFoundException($"Pedido com ID {id} não encontrado.");
        }

        pedidoExiste.Status = updatePedidoDto.Status;
        _context.Pedidos.Update(pedidoExiste);
    }

    public IEnumerable<Produto> GetAllProduto() {
        return _context.Produtos.ToList();
    }
    public Produto GetProdutoById(int id) => _context.Produtos.FirstOrDefault(c => c.ProductId == id);


    //parte assíncrona - ItemPedido e Pedido
    public IEnumerable<ItemPedido> GetAllItensPedido() {
        return _context.ItensPedido.ToList();
    }

    public ItemPedido GetItemPedidoById(int id) => _context.ItensPedido.FirstOrDefault(c => c.ItemPedidoKey == id);

    public IEnumerable<PedidoCliente> GetAllPedidos() {
        //return _context.Pedidos.ToList();
        return _context.Pedidos.Include(p => p.Itens).ToList();
    }

    public PedidoCliente GetPedidoById(int id) => _context.Pedidos.Include(p => p.Itens).FirstOrDefault(c => c.PedidoKey == id);

    public void CreatePedido(PedidoCliente pedido) {
        if(pedido==null) {
            throw new ArgumentNullException(nameof(pedido));
        }
        _context.Pedidos.Add(pedido);
    }
}