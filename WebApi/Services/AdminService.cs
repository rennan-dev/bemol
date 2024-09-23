using AutoMapper;
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
    private AdminDbContext _context;

    public AdminService(IMapper mapper, UserManager<Admin> userManager, SignInManager<Admin> signInManager, TokenService tokenService, AdminDbContext context) {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _context = context;
    }

    public async Task CadastraAdmin(CreateAdminDto adminDto) {
        Admin admin = _mapper.Map<Admin>(adminDto);

        IdentityResult resultado = await _userManager.CreateAsync(admin, adminDto.Password);

        if(!resultado.Succeeded) {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    public async Task<string> Login(LoginAdminDto adminDto) {
        var resultado = await _signInManager.PasswordSignInAsync(adminDto.Username, adminDto.Password, false, false);

        if(!resultado.Succeeded) {
            throw new ApplicationException("Usuário não autenticado");
        }

        var admin = _signInManager.UserManager.Users.FirstOrDefault(admin => admin.NormalizedUserName == adminDto.Username.ToUpper());

        var token = _tokenService.GenerateToken(admin);

        return token;
    }

    public async Task Logout() {
        await _signInManager.SignOutAsync();
    }

    public async Task<string> EmprestarLivro(int clienteId, int livroId) {
        var cliente = await _context.Clientes.Include(c => c.Livros).FirstOrDefaultAsync(c => c.Id == clienteId);
        if(cliente == null) {
            throw new ApplicationException("Cliente não encontrado.");
        }

        var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == livroId);
        if(livro == null) {
            throw new ApplicationException("Livro não encontrado.");
        }

        if(cliente.Livros.Count() >= 3) {
            throw new ApplicationException("O usuário não pode emprestar mais livros pois já tem 3 livros consigo.");
        }

        if(livro.EstaEmprestado) {
            throw new ApplicationException("O livro já está emprestado.");
        }

        cliente.Livros.Add(livro);
        livro.EstaEmprestado = true;

        await _context.SaveChangesAsync();
        return $"Livro emprestado para {cliente.Nome}";
    }

    public async Task<string> DevolverLivro(int livroId) {
        var livro = _context.Livros.FirstOrDefault(livro => livro.Id==livroId);
        if(livro == null) throw new ApplicationException("Livro não encontrado.");

        if(!livro.EstaEmprestado) throw new ApplicationException("O livro já está na biblioteca");

        livro.ClienteId = null;
        livro.EstaEmprestado = false;
        
        await _context.SaveChangesAsync();
        return $"O livro '{livro.Titulo}' foi devolvido.";
    }
}
