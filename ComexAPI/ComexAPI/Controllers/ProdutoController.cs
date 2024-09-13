using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : Controller {

    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um produto ao banco de dados do ComexAPI
    /// </summary>
    /// <param name="produtoDto">Objetos com os campos necessários para a criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostProduto([FromBody] CreateProdutoDto produtoDto) {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }

    /// <summary>
    /// Retorna todos os produtos armazenados no banco de dados do ComexAPI.
    /// </summary>
    /// <returns>IEnumerable&lt;ReadProdutoDto&gt;</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadProdutoDto> GetProdutos() {
        var produto = _context.Produtos.Include(c => c.Categoria).ToList();
        return _mapper.Map<IEnumerable<ReadProdutoDto>>(produto);
    }

    /// <summary>
    /// Retorna os detalhes de um produto específico armazenado no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do produto a ser retornado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Retornado quando o produto não é encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RecuperaProdutoPorId(int id) {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    /// <summary>
    /// Atualiza completamente um produto existente no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do produto a ser atualizado.</param>
    /// <param name="produtoDto">Objeto com os campos necessários para a atualização de um produto.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Retornado quando o produto não é encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutProduto(int id, [FromBody] UpdateProdutoDto produtoDto) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var produtoExistente = _context.Produtos.FirstOrDefault(x => x.Id == id);
        if(produtoExistente == null) { return NotFound(); }

        _mapper.Map(produtoDto, produtoExistente);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um produto parcialmente no banco de dados do ComexAPI
    /// </summary>
    /// <param name="id">ID do produto a ser atualizado.</param>
    /// <param name="patch">Documento JSON contendo as operações de patch a serem aplicadas.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Retornado quando o produto não é encontrado.</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PatchProduto(int id, JsonPatchDocument<UpdateProdutoDto> patch) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
        if (produto == null) { return NotFound(); }

        var produtoParaAtualizar = _mapper.Map<UpdateProdutoDto>(produto);
        patch.ApplyTo(produtoParaAtualizar, ModelState);

        if(!TryValidateModel(produtoParaAtualizar)) {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(produtoParaAtualizar, produto);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um produto do banco de dados do ComexAPI
    /// </summary>
    /// <param name="id">ID do produto a ser removido.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a deletação seja feita com sucesso</response>
    /// <response code="404">Retornado quando o produto não é encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteProduto(int id) {
        var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
        if (produto == null) { return NotFound(); }

        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }

}