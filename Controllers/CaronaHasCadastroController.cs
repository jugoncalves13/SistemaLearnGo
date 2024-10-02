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
    public class CaronaHasCadastroController : Controller
    {
        private readonly Contexto _context;

        public CaronaHasCadastroController(Contexto context)
        {
            _context = context;
        }

        // GET: CaronaHasCadastro
        public async Task<IActionResult> Index()
        {
            var contexto = _context.CaronaHasCadastro.Include(c => c.Cadastro).Include(c => c.Carona);
            return View(await contexto.ToListAsync());
        }

        // GET: CaronaHasCadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CaronaHasCadastro == null)
            {
                return NotFound();
            }

            var caronaHasCadastro = await _context.CaronaHasCadastro
                .Include(c => c.Cadastro)
                .Include(c => c.Carona)
                .FirstOrDefaultAsync(m => m.CaronaHasCadastroId == id);
            if (caronaHasCadastro == null)
            {
                return NotFound();
            }

            return View(caronaHasCadastro);
        }

        // GET: CaronaHasCadastro/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId");
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaId");
            return View();
        }

        // POST: CaronaHasCadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaronaHasCadastroId,CadastroId,CaronaId")] CaronaHasCadastro caronaHasCadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caronaHasCadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", caronaHasCadastro.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaId", caronaHasCadastro.CaronaId);
            return View(caronaHasCadastro);
        }

        // GET: CaronaHasCadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CaronaHasCadastro == null)
            {
                return NotFound();
            }

            var caronaHasCadastro = await _context.CaronaHasCadastro.FindAsync(id);
            if (caronaHasCadastro == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", caronaHasCadastro.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaId", caronaHasCadastro.CaronaId);
            return View(caronaHasCadastro);
        }

        // POST: CaronaHasCadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaronaHasCadastroId,CadastroId,CaronaId")] CaronaHasCadastro caronaHasCadastro)
        {
            if (id != caronaHasCadastro.CaronaHasCadastroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caronaHasCadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaronaHasCadastroExists(caronaHasCadastro.CaronaHasCadastroId))
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
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", caronaHasCadastro.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaId", caronaHasCadastro.CaronaId);
            return View(caronaHasCadastro);
        }

        // GET: CaronaHasCadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CaronaHasCadastro == null)
            {
                return NotFound();
            }

            var caronaHasCadastro = await _context.CaronaHasCadastro
                .Include(c => c.Cadastro)
                .Include(c => c.Carona)
                .FirstOrDefaultAsync(m => m.CaronaHasCadastroId == id);
            if (caronaHasCadastro == null)
            {
                return NotFound();
            }

            return View(caronaHasCadastro);
        }

        // POST: CaronaHasCadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CaronaHasCadastro == null)
            {
                return Problem("Entity set 'Contexto.CaronaHasCadastro'  is null.");
            }
            var caronaHasCadastro = await _context.CaronaHasCadastro.FindAsync(id);
            if (caronaHasCadastro != null)
            {
                _context.CaronaHasCadastro.Remove(caronaHasCadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaronaHasCadastroExists(int id)
        {
          return (_context.CaronaHasCadastro?.Any(e => e.CaronaHasCadastroId == id)).GetValueOrDefault();
        }
    }
}
