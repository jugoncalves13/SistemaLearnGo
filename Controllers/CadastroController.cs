using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaLearnGo.Models;

namespace SistemaLearnGo.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        public CadastroController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Login(Cadastro cadastro)
        {
            if (cadastro.CadastroEmail == "")
                return View();
            else
            {
                var verificaLogin = _context.Cadastro.Where(x => x.CadastroEmail == cadastro.CadastroEmail
                && x.CadastroSenha == cadastro.CadastroSenha).FirstOrDefault();
                if (verificaLogin == null)
                {
                    ViewBag.Mensagem = "Usuário ou senha não existe";
                    return View();
                }
                else
                {
                    return View("~/Views/Home/Index.cshtml");
                }
            }
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Cadastro.Include(c => c.Faculdade);
            return View(await contexto.ToListAsync());
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .Include(c => c.Faculdade)
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            ViewData["FaculdadeId"] = new SelectList(_context.Faculdade, "FaculdadeId", "FaculdadeNome");
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroId,CadastroNomeCompleto,CadastroDataNascimento,CadastroRm,CadastroCurso,CadastroEmail,CadastroSenha,CadastroEndereço,FaculdadeId")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FaculdadeId"] = new SelectList(_context.Faculdade, "FaculdadeId", "FaculdadeNome", cadastro.FaculdadeId);
            return View(cadastro);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            ViewData["FaculdadeId"] = new SelectList(_context.Faculdade, "FaculdadeId", "FaculdadeNome", cadastro.FaculdadeId);
            return View(cadastro);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastroId,CadastroNomeCompleto,CadastroDataNascimento,CadastroRm,CadastroCurso,CadastroEmail,CadastroSenha,CadastroEndereço,FaculdadeId")] Cadastro cadastro)
        {
            if (id != cadastro.CadastroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.CadastroId))
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
            ViewData["FaculdadeId"] = new SelectList(_context.Faculdade, "FaculdadeId", "FaculdadeNome", cadastro.FaculdadeId);
            return View(cadastro);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .Include(c => c.Faculdade)
                .FirstOrDefaultAsync(m => m.CadastroId == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastro == null)
            {
                return Problem("Entity set 'Contexto.Cadastro'  is null.");
            }
            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastro.Remove(cadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
          return (_context.Cadastro?.Any(e => e.CadastroId == id)).GetValueOrDefault();
        }
    }
}
