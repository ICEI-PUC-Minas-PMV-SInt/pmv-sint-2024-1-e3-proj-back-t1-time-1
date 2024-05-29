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
    public class PedidoComprasController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoComprasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PedidoCompras
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoCompra.Include(p => p.Fornecedor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PedidoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompra = await _context.PedidoCompra
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }

            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Create
        public IActionResult Create()
        {
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "Id", "Bairro");
            return View();
        }

        // POST: PedidoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataCompra,NotaFiscal,TotalPedido,IdFornecedor")] PedidoCompra pedidoCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "Id", "Bairro", pedidoCompra.IdFornecedor);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompra = await _context.PedidoCompra.FindAsync(id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "Id", "Bairro", pedidoCompra.IdFornecedor);
            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataCompra,NotaFiscal,TotalPedido,IdFornecedor")] PedidoCompra pedidoCompra)
        {
            if (id != pedidoCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoCompraExists(pedidoCompra.Id))
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
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedor, "Id", "Bairro", pedidoCompra.IdFornecedor);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompra = await _context.PedidoCompra
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }

            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoCompra = await _context.PedidoCompra.FindAsync(id);
            if (pedidoCompra != null)
            {
                _context.PedidoCompra.Remove(pedidoCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoCompraExists(int id)
        {
            return _context.PedidoCompra.Any(e => e.Id == id);
        }
    }
}
