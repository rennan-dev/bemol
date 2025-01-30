using AutoMapper;
using Estoque.Data;
using Estoque.Dtos;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase {

    private readonly IEstoqueRepository _repository;
    private readonly IMapper _mapper;

    public ProdutoController(IEstoqueRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadProdutoDto>> GetAllProdutos() {
        var produtos = _repository.GetAllProduto();
        return Ok(_mapper.Map<IEnumerable<ReadProdutoDto>>(produtos));
    }

    [HttpGet("{id}", Name = "GetProdutoById")]
    public ActionResult<ReadProdutoDto> GetProdutoById(int id) {
        var produto = _repository.GetProdutoById(id);
        if(produto!=null) {
            return Ok(_mapper.Map<ReadProdutoDto>(produto));
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ReadProdutoDto>> CreateProduto(CreateProdutoDto createProdutoDto) {
        var produto = _mapper.Map<Produto>(createProdutoDto);
        _repository.CreateProduto(produto);
        _repository.SaveChanges();

        var readProdutoDto = _mapper.Map<ReadProdutoDto>(produto);

        return await Task.FromResult(CreatedAtRoute(nameof(GetProdutoById), new { id = readProdutoDto.ProductId }, readProdutoDto));
    }
}