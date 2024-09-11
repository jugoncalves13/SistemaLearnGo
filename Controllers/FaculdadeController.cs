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
    public class FaculdadeController : Controller
    {
        private readonly Contexto _context;

        public FaculdadeController(Contexto context)
        {
            _context = context;
        }

        // GET: Faculdade
        public async Task<IActionResult> Index()
        {
              return _context.Faculdade != null ? 
                          View(await _context.Faculdade.ToListAsync()) :
                          Problem("Entity set 'Contexto.Faculdade'  is null.");
        }

        // GET: Faculdade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Faculdade == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade
                .FirstOrDefaultAsync(m => m.FaculdadeId == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // GET: Faculdade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculdade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaculdadeId,FaculdadeNome,FaculdadeCidade")] Faculdade faculdade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculdade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculdade);
        }

        // GET: Faculdade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Faculdade == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade.FindAsync(id);
            if (faculdade == null)
            {
                return NotFound();
            }
            return View(faculdade);
        }

        // POST: Faculdade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaculdadeId,FaculdadeNome,FaculdadeCidade")] Faculdade faculdade)
        {
            if (id != faculdade.FaculdadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculdade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaculdadeExists(faculdade.FaculdadeId))
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
            return View(faculdade);
        }

        // GET: Faculdade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Faculdade == null)
            {
                return NotFound();
            }

            var faculdade = await _context.Faculdade
                .FirstOrDefaultAsync(m => m.FaculdadeId == id);
            if (faculdade == null)
            {
                return NotFound();
            }

            return View(faculdade);
        }

        // POST: Faculdade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Faculdade == null)
            {
                return Problem("Entity set 'Contexto.Faculdade'  is null.");
            }
            var faculdade = await _context.Faculdade.FindAsync(id);
            if (faculdade != null)
            {
                _context.Faculdade.Remove(faculdade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaculdadeExists(int id)
        {
          return (_context.Faculdade?.Any(e => e.FaculdadeId == id)).GetValueOrDefault();
        }
    }
}
