using Pedido.Models;

namespace Pedido.Data.ProdutoRepository;

public interface IProdutoRepository {
    void SaveChanges();
    IEnumerable<Produto> GetAllProduto();
    void CreateProduto(Produto produto);
    bool ProdutoExiste(int ProductId);
    bool ExisteProdutoExterno(int produtoIdExterno);
}