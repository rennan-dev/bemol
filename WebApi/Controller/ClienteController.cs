using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Dtos;
using WebApi.Data;
using WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controller;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase {

    private IMapper _mapper;
    private AdminDbContext _context;

    public ClienteController(IMapper mapper, AdminDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    /// <summary>
    /// Adiciona um novo cliente ao banco de dados.
    /// </summary>
    /// <param name="clienteDto">Objeto com os campos necessários para criar um cliente.</param>
    /// <returns>Retorna os dados do cliente recém-criado.</returns>
    /// <response code="201">Caso o cliente seja criado com sucesso.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostCliente(CreateClienteDto clienteDto) {

        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        cliente.Livros = new List<Livro>();
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetClientePorId), new { id = cliente.Id }, clienteDto);
    }

    /// <summary>
    /// Obtém um cliente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente.</param>
    /// <returns>Dados do cliente correspondente ao ID fornecido.</returns>
    /// <response code="200">Se o cliente for encontrado com sucesso.</response>
    /// <response code="404">Se o cliente não for encontrado.</response>
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
    /// Obtém uma lista de todos os clientes.
    /// </summary>
    /// <returns>Lista de clientes.</returns>
    /// <response code="200">Caso a lista seja retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadClienteDto> GetCliente() {
        var clientes = _context.Clientes
            .Include(c => c.Livros) 
            .ToList();

        return _mapper.Map<List<ReadClienteDto>>(clientes);
    }

    /// <summary>
    /// Atualiza os dados de um cliente existente.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="clienteDto">Dados atualizados do cliente.</param>
    /// <returns>Resposta indicando sucesso ou falha.</returns>
    /// <response code="204">Se a atualização for feita com sucesso.</response>
    /// <response code="400">Se o modelo for inválido.</response>
    /// <response code="404">Se o cliente não for encontrado.</response>
    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutCliente(int id, UpdateClienteDto clienteDto) {
        if(!ModelState.IsValid) {
            return BadRequest();
        }

        var cliente = _context.Clientes.FirstOrDefault(cliente=>cliente.Id==id);
        if(cliente == null) return NotFound();

        _mapper.Map<UpdateClienteDto>(cliente);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Remove um cliente do banco de dados.
    /// </summary>
    /// <param name="id">ID do cliente a ser removido.</param>
    /// <returns>Resposta indicando sucesso ou falha.</returns>
    /// <response code="204">Se o cliente for removido com sucesso.</response>
    /// <response code="404">Se o cliente não for encontrado.</response>
    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteCliente(int id) {
        var cliente = _context.Clientes.FirstOrDefault(cliente=>cliente.Id==id);
        if(cliente == null) return NotFound();

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }   
}
