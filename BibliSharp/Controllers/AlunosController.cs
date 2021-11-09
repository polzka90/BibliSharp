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
    [Authorize(Policy = "IsUser")]
    public class AlunosController : Controller
    {
        private readonly BibliotecaContexto _context;

        public AlunosController(BibliotecaContexto context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Sala,Periodo,Ativo,DataCreacao,CriadoPor,DataAlteracao,AlteradoPor")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
                aluno.CriadoPor = user.Value;
                aluno.DataCreacao = DateTime.Now;
                aluno.AlteradoPor = user.Value;
                aluno.DataAlteracao = DateTime.Now;
                aluno.Ativo = true;
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Sala,Periodo,Ativo,DataAlteracao,AlteradoPor")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);

                    aluno.AlteradoPor = user.Value;
                    aluno.DataAlteracao = DateTime.Now;

                    var alunoDb = _context.Alunos.Single(a => a.Id == aluno.Id);

                    // Update the properties
                    _context.Entry(alunoDb).CurrentValues.SetValues(aluno);

                    //_context.Alunos.Attach(aluno);
                    _context.Entry(alunoDb).Property(x => x.CriadoPor).IsModified = false;
                    _context.Entry(alunoDb).Property(x => x.DataCreacao).IsModified = false;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
