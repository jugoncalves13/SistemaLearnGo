﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaLearnGo.Models;

namespace SistemaLearnGo.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly Contexto _context;

        public AvaliacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Avaliacao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Avaliacao.Include(a => a.Cadastro).Include(a => a.Carona);
            return View(await contexto.ToListAsync());
        }

        // GET: Avaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Avaliacao == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .Include(a => a.Cadastro)
                .Include(a => a.Carona)
                .FirstOrDefaultAsync(m => m.AvaliacaoId == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacao/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroNomeCompleto");
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaHorario");
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoId,CadastroId,CaronaId,AvaliacaoComentario")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroNomeCompleto", avaliacao.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaHorario", avaliacao.CaronaId);
            return View(avaliacao);
        }

        // GET: Avaliacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avaliacao == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroNomeCompleto", avaliacao.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaHorario", avaliacao.CaronaId);
            return View(avaliacao);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoId,CadastroId,CaronaId,AvaliacaoComentario")] Avaliacao avaliacao)
        {
            if (id != avaliacao.AvaliacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.AvaliacaoId))
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
            ViewData["CadastroId"] = new SelectList(_context.Cadastro, "CadastroId", "CadastroNomeCompleto", avaliacao.CadastroId);
            ViewData["CaronaId"] = new SelectList(_context.Carona, "CaronaId", "CaronaHorario", avaliacao.CaronaId);
            return View(avaliacao);
        }

        // GET: Avaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avaliacao == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .Include(a => a.Cadastro)
                .Include(a => a.Carona)
                .FirstOrDefaultAsync(m => m.AvaliacaoId == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avaliacao == null)
            {
                return Problem("Entity set 'Contexto.Avaliacao'  is null.");
            }
            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacao.Remove(avaliacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
          return (_context.Avaliacao?.Any(e => e.AvaliacaoId == id)).GetValueOrDefault();
        }
    }
}
