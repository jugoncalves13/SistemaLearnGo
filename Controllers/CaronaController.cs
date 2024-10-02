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
    public class CaronaController : Controller
    {
        private readonly Contexto _context;

        public CaronaController(Contexto context)
        {
            _context = context;
        }

        // GET: Carona
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Carona.Include(c => c.Cadastro).Include(c => c.CaronaTipo);
            return View(await contexto.ToListAsync());
        }

        // GET: Carona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carona == null)
            {
                return NotFound();
            }

            var carona = await _context.Carona
                .Include(c => c.Cadastro)
                .Include(c => c.CaronaTipo)
                .FirstOrDefaultAsync(m => m.CaronaId == id);
            if (carona == null)
            {
                return NotFound();
            }

            return View(carona);
        }

        // GET: Carona/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId");
            ViewData["CaronaTipoId"] = new SelectList(_context.CaronaTipo, "CaronaTipoId", "CaronaTipoId");
            return View();
        }

        // POST: Carona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaronaId,CaronaHorario,CaronaVeiculo,CaronaVagas,CaronaOrigem,CaronaDestino,CadastroId,CaronaTipoId")] Carona carona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", carona.CadastroId);
            ViewData["CaronaTipoId"] = new SelectList(_context.CaronaTipo, "CaronaTipoId", "CaronaTipoId", carona.CaronaTipoId);
            return View(carona);
        }

        // GET: Carona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carona == null)
            {
                return NotFound();
            }

            var carona = await _context.Carona.FindAsync(id);
            if (carona == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", carona.CadastroId);
            ViewData["CaronaTipoId"] = new SelectList(_context.CaronaTipo, "CaronaTipoId", "CaronaTipoId", carona.CaronaTipoId);
            return View(carona);
        }

        // POST: Carona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaronaId,CaronaHorario,CaronaVeiculo,CaronaVagas,CaronaOrigem,CaronaDestino,CadastroId,CaronaTipoId")] Carona carona)
        {
            if (id != carona.CaronaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaronaExists(carona.CaronaId))
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
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroId", carona.CadastroId);
            ViewData["CaronaTipoId"] = new SelectList(_context.CaronaTipo, "CaronaTipoId", "CaronaTipoId", carona.CaronaTipoId);
            return View(carona);
        }

        // GET: Carona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carona == null)
            {
                return NotFound();
            }

            var carona = await _context.Carona
                .Include(c => c.Cadastro)
                .Include(c => c.CaronaTipo)
                .FirstOrDefaultAsync(m => m.CaronaId == id);
            if (carona == null)
            {
                return NotFound();
            }

            return View(carona);
        }

        // POST: Carona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carona == null)
            {
                return Problem("Entity set 'Contexto.Carona'  is null.");
            }
            var carona = await _context.Carona.FindAsync(id);
            if (carona != null)
            {
                _context.Carona.Remove(carona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaronaExists(int id)
        {
          return (_context.Carona?.Any(e => e.CaronaId == id)).GetValueOrDefault();
        }
    }
}
