using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.Dtos;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controller;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase {

    private AdminService _adminService;

    public AdminController(AdminService cadastroService) {
        _adminService = cadastroService;
    }

    /// <summary>
    /// Adiciona um administrador ao banco de dados do WebAPI
    /// </summary>
    /// <param name="adminDto">Objetos com os campos necessários para a criação de um admin</param>
    /// <returns>
    /// Task
    /// </returns>
    /// <response code="200">Caso inserção seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateAdminDto adminDto) {
        await _adminService.CadastraAdmin(adminDto);
        return Ok("Admin cadastrado!");
    }

    /// <summary>
    /// Faz login no sistema como admin
    /// </summary>
    /// <param name="adminDto">Objetos com os campos necessários para a realização do login</param>
    /// <returns>
    /// Task
    /// </returns>
    /// <response code="200">Caso login seja feito com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginAdminDto adminDto) {
        var token = await _adminService.Login(adminDto);
        return Ok(token);
    }

    /// <summary>
    /// Faz login com um administrador no WebAPI
    /// </summary>
    /// <returns>
    /// Task
    /// </returns>
    /// <response code="200">Caso o admin se deslogue com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout() {
        await _adminService.Logout();
        return Ok("Logout realizado com sucesso.");
    }

    /// <summary>
    /// Empresta um livro para um cliente
    /// </summary>
    /// <param name="clienteId, livroId">Objetos com os campos necessários para emprestar um livro</param>
    /// <returns>
    /// Task
    /// </returns>
    /// <response code="200">Caso tenhha emprestado um livro com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Emprestar/{clienteId}/Livro/{livroId}")]
    [Authorize]
    public async Task<IActionResult> EmprestarLivro(int clienteId, int livroId) {
        string resultado;
        try {
            resultado = await _adminService.EmprestarLivro(clienteId, livroId);
            return Ok(resultado);
        }catch (ApplicationException ex) {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Devolve um livro para WebAPI
    /// </summary>
    /// <param name="livroId"></param>
    /// <returns>
    /// Task
    /// </returns>
    /// <response code="200">Caso a devolução seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("Devolver/{livroId}")]
    [Authorize]
    public async Task<IActionResult> DevolverLivro(int livroId) {
        string resultado;
        try {
            resultado = await _adminService.DevolverLivro(livroId);
            return Ok(resultado);
        }catch (ApplicationException ex) {
            return BadRequest(ex.Message);
        }
    }
}
