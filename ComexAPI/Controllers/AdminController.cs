using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Dtos;
using WebApi.Services;

namespace ComexAPI.Controllers;
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
}
