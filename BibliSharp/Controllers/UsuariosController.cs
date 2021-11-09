using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliSharp.DbModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BibliSharp.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class UsuariosController : Controller
    {
        private readonly BibliotecaContexto _context;

        public UsuariosController(BibliotecaContexto context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUsuario,Nome,Sobrenome,Senha,Ativo,DataCreacao,CriadoPor,DataAlteracao,AlteradoPor")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
                usuario.CriadoPor = user.Value;
                usuario.DataCreacao = DateTime.Now;
                usuario.AlteradoPor = user.Value;
                usuario.DataAlteracao = DateTime.Now;
                usuario.Ativo = true;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUsuario,Nome,Sobrenome,Senha,Ativo,DataCreacao,CriadoPor,DataAlteracao,AlteradoPor")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);

                    usuario.AlteradoPor = user.Value;
                    usuario.DataAlteracao = DateTime.Now;

                    //if (string.IsNullOrWhiteSpace(usuario.Senha))
                    //{
                    //    var usuariodb = await _context.Usuarios.FindAsync(id);
                    //    usuario.Senha = usuariodb.Senha;
                    //}
                    // Update the properties
                    var usuarioDb = _context.Usuarios.Single(a => a.Id == usuario.Id);
                    _context.Entry(usuarioDb).CurrentValues.SetValues(usuario);

                    _context.Entry(usuarioDb).Property(x => x.Senha).IsModified = !(string.IsNullOrWhiteSpace(usuario.Senha));
                    _context.Entry(usuarioDb).Property(x => x.CriadoPor).IsModified = false;
                    _context.Entry(usuarioDb).Property(x => x.DataCreacao).IsModified = false;
                    _context.Entry(usuarioDb).Property(x => x.Ativo).IsModified = false;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            usuario.Ativo = false;
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
