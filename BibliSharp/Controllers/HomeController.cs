using BibliSharp.DbModels;
using BibliSharp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BibliSharp.Controllers
{

    //[Authorize(Policy = "Admin")]
    //[Authorize(Policy = "User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotecaContexto _context;

        public HomeController(ILogger<HomeController> logger, BibliotecaContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario u)
        {
            // esta action trata o post (login)
            string nomeUsuario= string.Empty, role = string.Empty, id = string.Empty;
            if (ModelState.IsValid) //verifica se é válido
            {
                if (u.NomeUsuario.ToLower() == "admin" && u.Senha == "123456")
                {
                    nomeUsuario = u.NomeUsuario;
                    role = "Admin";
                    id = "0";
                }
                else
                {
                    var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.NomeUsuario == u.NomeUsuario && m.Senha == u.Senha && m.Ativo);

                    if (usuario != null)
                    {

                        nomeUsuario = usuario.NomeUsuario;
                        role = "User";
                        id = usuario.Id.ToString();
                    }
                }
                if(!string.IsNullOrWhiteSpace(nomeUsuario))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, nomeUsuario),
                        new Claim("usuarioLogadoID", id),
                        new Claim(ClaimTypes.Role, role),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index");
                }
            }
            return View(u);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
