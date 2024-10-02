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
    public class CaronaTipoController : Controller
    {
        private readonly Contexto _context;

        public CaronaTipoController(Contexto context)
        {
            _context = context;
        }

        // GET: CaronaTipo
        public async Task<IActionResult> Index()
        {
              return _context.CaronaTipo != null ? 
                          View(await _context.CaronaTipo.ToListAsync()) :
                          Problem("Entity set 'Contexto.CaronaTipo'  is null.");
        }

        // GET: CaronaTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CaronaTipo == null)
            {
                return NotFound();
            }

            var caronaTipo = await _context.CaronaTipo
                .FirstOrDefaultAsync(m => m.CaronaTipoId == id);
            if (caronaTipo == null)
            {
                return NotFound();
            }

            return View(caronaTipo);
        }

        // GET: CaronaTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaronaTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaronaTipoId,CaronaTipoDescricao")] CaronaTipo caronaTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caronaTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caronaTipo);
        }

        // GET: CaronaTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CaronaTipo == null)
            {
                return NotFound();
            }

            var caronaTipo = await _context.CaronaTipo.FindAsync(id);
            if (caronaTipo == null)
            {
                return NotFound();
            }
            return View(caronaTipo);
        }

        // POST: CaronaTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaronaTipoId,CaronaTipoDescricao")] CaronaTipo caronaTipo)
        {
            if (id != caronaTipo.CaronaTipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caronaTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaronaTipoExists(caronaTipo.CaronaTipoId))
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
            return View(caronaTipo);
        }

        // GET: CaronaTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CaronaTipo == null)
            {
                return NotFound();
            }

            var caronaTipo = await _context.CaronaTipo
                .FirstOrDefaultAsync(m => m.CaronaTipoId == id);
            if (caronaTipo == null)
            {
                return NotFound();
            }

            return View(caronaTipo);
        }

        // POST: CaronaTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CaronaTipo == null)
            {
                return Problem("Entity set 'Contexto.CaronaTipo'  is null.");
            }
            var caronaTipo = await _context.CaronaTipo.FindAsync(id);
            if (caronaTipo != null)
            {
                _context.CaronaTipo.Remove(caronaTipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaronaTipoExists(int id)
        {
          return (_context.CaronaTipo?.Any(e => e.CaronaTipoId == id)).GetValueOrDefault();
        }
    }
}
