using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaConsultasUVV.Data;
using SistemaConsultasUVV.Models;

namespace SistemaConsultasUVV.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registro() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            // 1. Atribui a data atual
            usuario.DataCadastro = DateTime.Now;

            // 2. Remove da validação as propriedades que não vêm do formulário
            ModelState.Remove("DataCadastro");
            ModelState.Remove("Consultas"); // <-- ESSENCIAL se houver relação no model Usuario

            if (!string.IsNullOrEmpty(usuario.Email) && !usuario.Email.Contains("@"))
            {
                ModelState.AddModelError("Email", "Digite um e-mail válido contendo @.");
            }

            if (ModelState.IsValid)
            {
                var emailExiste = await _context.Usuarios
                    .AnyAsync(u => u.Email.ToLower() == usuario.Email.ToLower());

                if (emailExiste)
                {
                    ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                    return View(usuario);
                }

                usuario.Email = usuario.Email.Trim().ToLower();

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(usuario);
        }
        
        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult AcessoNegado() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                ViewBag.Erro = "E-mail ou senha inválidos.";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Consultas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Limpa os cookies de autenticação do navegador
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redireciona para a Home (Index)
            return RedirectToAction("Login", "Account");
}
    }
}