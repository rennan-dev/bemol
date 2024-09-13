using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : Controller {

    private ProdutoContext _context;
    private IMapper _mapper;

    public EnderecoController(ProdutoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um endereço ao banco de dados do ComexAPI
    /// </summary>
    /// <param name="EnderecoDto">Objetos com os campos necessários para a criação de um endereço</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostProduto([FromBody] CreateEnderecoDto EnderecoDto) {
        Endereco endereco = _mapper.Map<Endereco>(EnderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    /// <summary>
    /// Retorna os detalhes de um endereço específico armazenado no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do endereço a ser retornado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Retornado quando o endereço não é encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEnderecoPorId(int id) {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    /// <summary>
    /// Retorna todos os endereços armazenados no banco de dados do ComexAPI.
    /// </summary>
    /// <returns>IEnumerable&lt;ReadEnderecoDto&gt;</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadEnderecoDto> GetEnderecos() {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }

    /// <summary>
    /// Atualiza completamente um endereço existente no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do endereço a ser atualizado.</param>
    /// <param name="enderecoDto">Objeto com os campos necessários para a atualização de um endereço.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Retornado quando o endereço não é encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if(endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um endereço do banco de dados do ComexAPI
    /// </summary>
    /// <param name="id">ID do endereço a ser removido.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a deletação seja feita com sucesso</response>
    /// <response code="404">Retornado quando o endereço não é encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteEndereco(int id) {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if(endereco == null) return NotFound();
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
