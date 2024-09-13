using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase {

    private ProdutoContext _context;
    private IMapper _mapper;

    public CategoriaController(ProdutoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma categoria ao banco de dados do ComexAPI
    /// </summary>
    /// <param name="CategoriaDto">Objetos com os campos necessários para a criação de uma categoria</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostCategoria([FromBody] CreateCategoriaDto categoriaDto) {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCategoriaPorId), new { id = categoria.Id }, categoria);
    }

    /// <summary>
    /// Retorna os detalhes de uma categoria específica armazenada no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID da categoria a ser retornado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Retornado quando a categoria não é encontrada.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCategoriaPorId(int id) {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if(categoria == null) return NotFound();
        ReadCategoriaDto categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
        return Ok(categoriaDto);
    }

    /// <summary>
    /// Retorna todas as categorias armazenadas no banco de dados do ComexAPI.
    /// </summary>
    /// <returns>IEnumerable&lt;ReadCategoriaDto&gt;</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadCategoriaDto> GetCategoria() {
        return _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias);
    }

    /// <summary>
    /// Atualiza completamente uma categoria existente no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID da categoria a ser atualizado.</param>
    /// <param name="categoriaDto">Objeto com os campos necessários para a atualização de uma categoria.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Retornado quando a categoria não é encontrada.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutCategoria(int id, [FromBody] ReadCategoriaDto categoriaDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
        if(categoria == null) return NotFound();

        _mapper.Map(categoriaDto, categoria);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta uma categoria do banco de dados do ComexAPI
    /// </summary>
    /// <param name="id">ID da categoria a ser removido.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a deletação seja feita com sucesso</response>
    /// <response code="404">Retornado quando a categoria não é encontrada.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteCategoria(int id) {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
        if(categoria == null) return NotFound();
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return NoContent();
    }
}
