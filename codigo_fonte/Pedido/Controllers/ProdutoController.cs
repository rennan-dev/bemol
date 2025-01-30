using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pedido.Data.ProdutoRepository;
using Pedido.Dtos.Produto;
using Pedido.EstoqueHttpClient;

namespace Estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase {

    private readonly IProdutoRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEstoqueHttpClient _estoqueHttpClient;

    public ProdutoController(IProdutoRepository repository, IMapper mapper, IEstoqueHttpClient estoqueHttpClient) {
        _repository = repository;
        _mapper = mapper;
        _estoqueHttpClient = estoqueHttpClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadProdutoDto>>> GetProdutos() {
        var produtos = await _estoqueHttpClient.GetAllProdutos();  
        if(produtos == null || !produtos.Any()) {
            return NotFound("Nenhum produto encontrado.");
        }

        var produtosDto = _mapper.Map<IEnumerable<ReadProdutoDto>>(produtos);  
        return Ok(produtosDto); 
    }


    [HttpGet("{productId}")]
    public async Task<ActionResult> VerificaProduto(int productId) {
        var produto = await _estoqueHttpClient.GetProdutoPorId(productId);
        if (produto == null) {
            return NotFound($"Produto com ID {productId} não encontrado no Estoque.");
        }

        Console.WriteLine($"Produto encontrado: {JsonSerializer.Serialize(produto)}");
        return Ok(produto);
    }
}