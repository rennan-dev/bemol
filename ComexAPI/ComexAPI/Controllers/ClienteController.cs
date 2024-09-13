using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : Controller {

    private ProdutoContext _context;
    private IMapper _mapper;

    public ClienteController(ProdutoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um cliente ao banco de dados do ComexAPI
    /// </summary>
    /// <param name="ClienteDto">Objetos com os campos necessários para a criação de um cliente</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostCliente([FromBody] CreateClienteDto clienteDto) {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetClientePorId), new { id = cliente.Id }, cliente);
    }

    /// <summary>
    /// Retorna os detalhes de um cliente específico armazenado no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do cliente a ser retornado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    /// <response code="404">Retornado quando o cliente não é encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetClientePorId(int id) {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
        return Ok(clienteDto);
    }

    /// <summary>
    /// Retorna todos os clientes armazenados no banco de dados do ComexAPI.
    /// </summary>
    /// <returns>IEnumerable&lt;ReadClienteDto&gt;</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadClienteDto> GetClientes() {
        var clientes = _context.Clientes.Include(c => c.Endereco).ToList();
        return _mapper.Map<IEnumerable<ReadClienteDto>>(clientes);
    }

    /// <summary>
    /// Atualiza completamente um cliente existente no banco de dados do ComexAPI.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="clienteDto">Objeto com os campos necessários para a atualização de um cliente.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>
    /// <response code="404">Retornado quando o cliente não é encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutCliente(int id, [FromBody] UpdateClienteDto clienteDto) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if(cliente == null) return NotFound();

        _mapper.Map(clienteDto, cliente);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um cliente do banco de dados do ComexAPI
    /// </summary>
    /// <param name="id">ID do cliente a ser removido.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a deletação seja feita com sucesso</response>
    /// <response code="404">Retornado quando o cliente não é encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteCliente(int id) {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if(cliente == null) return NotFound();
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
