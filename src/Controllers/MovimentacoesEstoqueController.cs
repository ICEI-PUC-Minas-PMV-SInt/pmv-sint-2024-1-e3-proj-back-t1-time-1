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
    public class MovimentacoesEstoqueController : Controller
    {
        private readonly AppDbContext _context;

        public MovimentacoesEstoqueController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovimentacoesEstoque
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MovimentacaoEstoque.Include(m => m.ItemPedido);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MovimentacoesEstoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoEstoque = await _context.MovimentacaoEstoque
                .Include(m => m.ItemPedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoEstoque == null)
            {
                return NotFound();
            }

            return View(movimentacaoEstoque);
        }

        // GET: MovimentacoesEstoque/Create
        public IActionResult Create()
        {
            ViewData["ItemPedidoId"] = new SelectList(_context.ItemPedido, "Id", "Id");
            return View();
        }

        // POST: MovimentacoesEstoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemPedidoId,QuantidadeProduto,TipoMovimentacao,DataMovimentacao")] MovimentacaoEstoque movimentacaoEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacaoEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemPedidoId"] = new SelectList(_context.ItemPedido, "Id", "Id", movimentacaoEstoque.ItemPedidoId);
            return View(movimentacaoEstoque);
        }

        // GET: MovimentacoesEstoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoEstoque = await _context.MovimentacaoEstoque.FindAsync(id);
            if (movimentacaoEstoque == null)
            {
                return NotFound();
            }
            ViewData["ItemPedidoId"] = new SelectList(_context.ItemPedido, "Id", "Id", movimentacaoEstoque.ItemPedidoId);
            return View(movimentacaoEstoque);
        }

        // POST: MovimentacoesEstoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemPedidoId,QuantidadeProduto,TipoMovimentacao,DataMovimentacao")] MovimentacaoEstoque movimentacaoEstoque)
        {
            if (id != movimentacaoEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacaoEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoEstoqueExists(movimentacaoEstoque.Id))
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
            ViewData["ItemPedidoId"] = new SelectList(_context.ItemPedido, "Id", "Id", movimentacaoEstoque.ItemPedidoId);
            return View(movimentacaoEstoque);
        }

        // GET: MovimentacoesEstoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoEstoque = await _context.MovimentacaoEstoque
                .Include(m => m.ItemPedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoEstoque == null)
            {
                return NotFound();
            }

            return View(movimentacaoEstoque);
        }

        // POST: MovimentacoesEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacaoEstoque = await _context.MovimentacaoEstoque.FindAsync(id);
            if (movimentacaoEstoque != null)
            {
                _context.MovimentacaoEstoque.Remove(movimentacaoEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoEstoqueExists(int id)
        {
            return _context.MovimentacaoEstoque.Any(e => e.Id == id);
        }
    }
}
