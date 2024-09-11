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
    public class OfertarCaronaController : Controller
    {
        private readonly Contexto _context;

        public OfertarCaronaController(Contexto context)
        {
            _context = context;
        }

        // GET: OfertarCarona
        public async Task<IActionResult> Index()
        {
              return _context.OfertarCarona != null ? 
                          View(await _context.OfertarCarona.ToListAsync()) :
                          Problem("Entity set 'Contexto.OfertarCarona'  is null.");
        }

        // GET: OfertarCarona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OfertarCarona == null)
            {
                return NotFound();
            }

            var ofertarCarona = await _context.OfertarCarona
                .FirstOrDefaultAsync(m => m.OfertarCaronaId == id);
            if (ofertarCarona == null)
            {
                return NotFound();
            }

            return View(ofertarCarona);
        }

        // GET: OfertarCarona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfertarCarona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfertarCaronaId,OfertarCaronaPeriodo,OfertarCaronaHorário,OfertarCaronaEndereço,OfertarCaronaVagas,OfertarCaronaVeiculo")] OfertarCarona ofertarCarona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofertarCarona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofertarCarona);
        }

        // GET: OfertarCarona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OfertarCarona == null)
            {
                return NotFound();
            }

            var ofertarCarona = await _context.OfertarCarona.FindAsync(id);
            if (ofertarCarona == null)
            {
                return NotFound();
            }
            return View(ofertarCarona);
        }

        // POST: OfertarCarona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfertarCaronaId,OfertarCaronaPeriodo,OfertarCaronaHorário,OfertarCaronaEndereço,OfertarCaronaVagas,OfertarCaronaVeiculo")] OfertarCarona ofertarCarona)
        {
            if (id != ofertarCarona.OfertarCaronaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofertarCarona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertarCaronaExists(ofertarCarona.OfertarCaronaId))
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
            return View(ofertarCarona);
        }

        // GET: OfertarCarona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OfertarCarona == null)
            {
                return NotFound();
            }

            var ofertarCarona = await _context.OfertarCarona
                .FirstOrDefaultAsync(m => m.OfertarCaronaId == id);
            if (ofertarCarona == null)
            {
                return NotFound();
            }

            return View(ofertarCarona);
        }

        // POST: OfertarCarona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OfertarCarona == null)
            {
                return Problem("Entity set 'Contexto.OfertarCarona'  is null.");
            }
            var ofertarCarona = await _context.OfertarCarona.FindAsync(id);
            if (ofertarCarona != null)
            {
                _context.OfertarCarona.Remove(ofertarCarona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertarCaronaExists(int id)
        {
          return (_context.OfertarCarona?.Any(e => e.OfertarCaronaId == id)).GetValueOrDefault();
        }
    }
}
