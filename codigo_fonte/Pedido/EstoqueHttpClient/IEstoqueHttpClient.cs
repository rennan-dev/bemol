using Pedido.Dtos.Produto;

namespace Pedido.EstoqueHttpClient;

public interface IEstoqueHttpClient {
    public Task<ReadProdutoDto> GetProdutoPorId(int productId);
    Task<IEnumerable<ReadProdutoDto>> GetAllProdutos();
}