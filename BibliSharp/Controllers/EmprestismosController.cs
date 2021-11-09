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
using BibliSharp.Models;

namespace BibliSharp.Controllers
{
    [Authorize(Policy = "IsUser")]
    public class EmprestismosController : Controller
    {
        private readonly BibliotecaContexto _context;

        public EmprestismosController(BibliotecaContexto context)
        {
            _context = context;
        }

        // GET: Emprestismos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emprestismos.ToListAsync());
        }

        // GET: Emprestismos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var emprestismo = await _context.Emprestismos
                .FirstOrDefaultAsync(m => m.EmprestismoId == id);
            if (emprestismo == null)
            {
                return NotFound();
            }
            DetailsEmprestismoViewModel model = new DetailsEmprestismoViewModel();
            model.Emprestismo = emprestismo;
            Aluno aluno = (await _context.Alunos.FirstOrDefaultAsync(a => a.Id == emprestismo.AlunoId));
            model.Aluno = aluno.Nome + " " + aluno.Sobrenome + " " + aluno.Periodo + " " + aluno.Sala;

            Livro livro = (await _context.Livros.FirstOrDefaultAsync(a => a.Id == emprestismo.LivroId));
            model.Livro = livro.Nome + " " + livro.Autora + " " + livro.Ano;

            return View(model);
        }

        // GET: Emprestismos/Create
        public async Task<IActionResult> Create()
        {
            List<Aluno> alunos = await _context.Alunos.Where(a => a.Ativo).ToListAsync();
            List<Livro> livros = await _context.Livros.ToListAsync();
            var model = new CreateEmprestismoViewModel();
            model.Alunos = alunos.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome + " " + x.Sobrenome + " " + x.Periodo + " " + x.Sala }).ToList();
            model.Livros = livros.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome + " " + x.Autora + " " + x.Ano }).ToList();
            model.Emprestismo = new Emprestismo();
            model.Emprestismo.DataLimite = DateTime.Now.AddDays(3);
            return View(model);
        }

        // POST: Emprestismos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmprestismoId,AlunoId,LivroId,DataRetirada,CriadoPor,DataLimite,DataEntrega,AlteradoPor")] Emprestismo emprestismo)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
                emprestismo.CriadoPor = user.Value;
                emprestismo.DataRetirada = DateTime.Now;
 

                _context.Add(emprestismo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emprestismo);
        }

        // GET: Emprestismos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestismo = await _context.Emprestismos.FirstOrDefaultAsync(i => i.EmprestismoId == id);
            if (emprestismo == null)
            {
                return NotFound();
            }
            emprestismo.DataEntrega = DateTime.Now;

            EditEmprestismoViewModel model = new EditEmprestismoViewModel();
            model.Emprestismo = emprestismo;
            Aluno aluno = (await _context.Alunos.FirstOrDefaultAsync(a => a.Id == emprestismo.AlunoId));
            model.Aluno = aluno.Nome + " " + aluno.Sobrenome + " " + aluno.Periodo + " " + aluno.Sala;

            Livro livro = (await _context.Livros.FirstOrDefaultAsync(a => a.Id == emprestismo.LivroId));
            model.Livro = livro.Nome + " " + livro.Autora + " " + livro.Ano;



            return View(model);
        }

        // POST: Emprestismos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmprestismoId,AlunoId,LivroId,DataRetirada,CriadoPor,DataLimite,DataEntrega,AlteradoPor")] Emprestismo emprestismo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);

                    emprestismo.AlteradoPor = user.Value;

                    var emprestismoDb = _context.Emprestismos.Single(a => a.EmprestismoId == emprestismo.EmprestismoId);

                    emprestismoDb.DataEntrega = emprestismo.DataEntrega;
                    emprestismoDb.AlteradoPor = user.Value;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestismoExists(emprestismo.AlunoId))
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
            return View(emprestismo);
        }

        // GET: Emprestismos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestismo = await _context.Emprestismos
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (emprestismo == null)
            {
                return NotFound();
            }

            return View(emprestismo);
        }

        // POST: Emprestismos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestismo = await _context.Emprestismos.FindAsync(id);
            _context.Emprestismos.Remove(emprestismo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Emprestismos/VerSemDevolucao
        public async Task<IActionResult> VerSemDevolucao()
        {
            return View(await _context.Emprestismos.Where(e => e.DataEntrega == DateTime.MinValue).ToListAsync());
        }
        private bool EmprestismoExists(int id)
        {
            return _context.Emprestismos.Any(e => e.AlunoId == id);
        }
    }
}
