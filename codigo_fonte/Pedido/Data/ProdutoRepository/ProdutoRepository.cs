using Pedido.Models;

namespace Pedido.Data.ProdutoRepository;

public class ProdutoRepository : IProdutoRepository {

    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context) {
        _context = context;
    }
    public void CreateProduto(Produto produto) {
        _context.Produtos.Add(produto);
    }

    public bool ExisteProdutoExterno(int produtoIdExterno) {
        return _context.Produtos.Any(produto => produto.ProductIdExterno == produtoIdExterno);
    }

    public IEnumerable<Produto> GetAllProduto() {
        return _context.Produtos.ToList();
    }

    public bool ProdutoExiste(int ProductId) {
        return _context.Produtos.Any(produto => produto.ProductId == ProductId);
    }

    public void SaveChanges() {
        _context.SaveChanges();
    }
}