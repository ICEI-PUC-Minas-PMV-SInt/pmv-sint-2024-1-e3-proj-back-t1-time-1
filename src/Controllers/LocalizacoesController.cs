using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharma.Models;

namespace Pharma.Controllers
{
    public class LocalizacoesController : Controller
    {
        private readonly AppDbContext _context;

        public LocalizacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Localizacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Localizacao.ToListAsync());
        }

        // GET: Localizacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // GET: Localizacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Capacidade")] Localizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        // GET: Localizacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacao.FindAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }
            return View(localizacao);
        }

        // POST: Localizacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Capacidade")] Localizacao localizacao)
        {
            if (id != localizacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localizacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizacaoExists(localizacao.Id))
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
            return View(localizacao);
        }

        // GET: Localizacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localizacao = await _context.Localizacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localizacao == null)
            {
                return NotFound();
            }

            return View(localizacao);
        }

        // POST: Localizacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localizacao = await _context.Localizacao.FindAsync(id);
            if (localizacao != null)
            {
                _context.Localizacao.Remove(localizacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizacaoExists(int id)
        {
            return _context.Localizacao.Any(e => e.Id == id);
        }
    }
}
