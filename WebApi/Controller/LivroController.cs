using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.Dtos;
using WebApi.Models;

namespace WebApi.Controller;

[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase {

    private IMapper _mapper;
    private AdminDbContext _context;

    public LivroController(IMapper mapper, AdminDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    /// <summary>
    /// Adiciona um novo livro ao banco de dados.
    /// </summary>
    /// <param name="livroDto">Objeto com os campos necessários para criar um livro.</param>
    /// <returns>Retorna os dados do livro recém-criado.</returns>
    /// <response code="201">Caso o livro seja criado com sucesso.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostLivro(CreateLivroDto livroDto) {

        Livro livro = _mapper.Map<Livro>(livroDto);
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLivroPorId), new { id = livro.Id }, livroDto);
    }



    /// <summary>
    /// Obtém um livro pelo ID.
    /// </summary>
    /// <param name="id">ID do livro.</param>
    /// <returns>Dados do livro correspondente ao ID fornecido.</returns>
    /// <response code="200">Se o livro for encontrado com sucesso.</response>
    /// <response code="404">Se o livro não for encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLivroPorId(int id) {
        var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
        if (livro == null) return NotFound();

        ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);
        return Ok(livroDto);
    }

    /// <summary>
    /// Obtém uma lista de todos os livros.
    /// </summary>
    /// <returns>Lista de livros.</returns>
    /// <response code="200">Caso a lista seja retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadLivroDto> GetLivro() {
        return _mapper.Map<List<ReadLivroDto>>(_context.Livros);
    }

    /// <summary>
    /// Atualiza os dados de um livro existente.
    /// </summary>
    /// <param name="id">ID do livro a ser atualizado.</param>
    /// <param name="livroDto">Dados atualizados do livro.</param>
    /// <returns>Resposta indicando sucesso ou falha.</returns>
    /// <response code="204">Se a atualização for feita com sucesso.</response>
    /// <response code="400">Se o modelo for inválido.</response>
    /// <response code="404">Se o livro não for encontrado.</response>
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutLivro(int id, UpdateLivroDto livroDto) {
        if(!ModelState.IsValid) {
            return BadRequest();
        }

        var livro = _context.Livros.FirstOrDefault(livro=>livro.Id == id);
        if(livro == null) return NotFound();

        _mapper.Map<UpdateLivroDto>(livro);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Remove um livro do banco de dados.
    /// </summary>
    /// <param name="id">ID do livro a ser removido.</param>
    /// <returns>Resposta indicando sucesso ou falha.</returns>
    /// <response code="204">Se o livro for removido com sucesso.</response>
    /// <response code="404">Se o livro não for encontrado.</response>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteLivro(int id) {
        var livro = _context.Livros.FirstOrDefault(livro=>livro.Id == id);
        if(livro == null) return NotFound();

        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return NoContent();
    }

}
