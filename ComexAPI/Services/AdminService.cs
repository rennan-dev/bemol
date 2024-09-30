using AutoMapper;
using ComexAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Dtos;
using WebApi.Models;

namespace WebApi.Services;
public class AdminService {

    private IMapper _mapper;
    private UserManager<Admin> _userManager;
    private SignInManager<Admin> _signInManager;
    private TokenService _tokenService;
    private ProdutoContext _context;

    public AdminService(IMapper mapper, UserManager<Admin> userManager, SignInManager<Admin> signInManager, TokenService tokenService, ProdutoContext context) {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _context = context;
    }

    public async Task CadastraAdmin(CreateAdminDto adminDto) {
        Admin admin = _mapper.Map<Admin>(adminDto);

        IdentityResult resultado = await _userManager.CreateAsync(admin, adminDto.Password);

        if (!resultado.Succeeded) {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    public async Task<string> Login(LoginAdminDto adminDto) {
        var resultado = await _signInManager.PasswordSignInAsync(adminDto.Username, adminDto.Password, false, false);

        if (!resultado.Succeeded) {
            throw new ApplicationException("Usuário não autenticado");
        }

        var admin = _signInManager.UserManager.Users.FirstOrDefault(admin => admin.NormalizedUserName == adminDto.Username.ToUpper());

        var token = _tokenService.GenerateToken(admin);

        return token;
    }

    public async Task Logout() {
        await _signInManager.SignOutAsync();
    }
}

