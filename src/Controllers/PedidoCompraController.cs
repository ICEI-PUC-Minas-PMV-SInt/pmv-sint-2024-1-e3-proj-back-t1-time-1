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
    public class PedidoCompraController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoCompraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PedidoCompra
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoCompra.Include(p => p.Compras);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PedidoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompras = await _context.PedidoCompra
                .Include(p => p.Compras)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }

            return View(pedidoCompra);
        }

        // GET: PedidoCompra/Create
        public IActionResult Create()
        {
            ViewData["IdPedidoCompra"] = new SelectList(_context.Set<Fornecedores>(), "Idfornecedor", "Idfornecedor");
            return View();
        }

        // POST: PedidoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,DtPedido,NtFiscal,TotalPedido,Idfornecedor")] PedidoCompra pedidocompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idfornecedor"] = new SelectList(_context.Set<Cliente>(), "Idfornecedor", "Idfornecedor", pedidoCompra.Idfornecedor);
            return View(pedidoCompra);
        }

        // GET: PedidoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompra = await _context.PedidoCliente.FindAsync(id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente", pedidoCompra.IdCliente);
            return View(pedidoCompra);
        }

        // POST: PedidoClompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,DtPedido,NtFiscal,TotalPedido,Idfornecedor")] PedidoCompra pedidoCompra)
        {
            if (id != pedidoCompra.IdPedido)
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
                    if (!PedidoClienteExists(pedidoCompra.IdPedido))
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
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente", pedidoCompra.IdFornecedor);
            return View(pedidoCompra);
        }

        // GET: PedidoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCompra = await _context.PedidoCompra
                .Include(p => p.Fornecedores)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoCompra == null)
            {
                return NotFound();
            }

            return View(pedidoCompra);
        }

        // POST: PedidoCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoCompra = await _context.PedidoCompra.FindAsync(id);
            if (pedidoCompra != null)
            {
                _context.PedidoCliente.Remove(pedidoCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoClienteExists(int id)
        {
            return _context.PedidoCliente.Any(e => e.IdPedido == id);
        }
    }
}
