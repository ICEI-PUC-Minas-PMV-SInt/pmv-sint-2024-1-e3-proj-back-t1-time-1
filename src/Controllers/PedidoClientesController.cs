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
    public class PedidoClientesController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PedidoClientes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoCliente.Include(p => p.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PedidoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente");
            return View();
        }

        // POST: PedidoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,DtPedido,NtFiscal,TotalPedido,IdCliente")] PedidoCliente pedidoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente", pedidoCliente.IdCliente);
            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente.FindAsync(id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente", pedidoCliente.IdCliente);
            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,DtPedido,NtFiscal,TotalPedido,IdCliente")] PedidoCliente pedidoCliente)
        {
            if (id != pedidoCliente.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoClienteExists(pedidoCliente.IdPedido))
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
            ViewData["IdCliente"] = new SelectList(_context.Set<Cliente>(), "IdCliente", "IdCliente", pedidoCliente.IdCliente);
            return View(pedidoCliente);
        }

        // GET: PedidoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // POST: PedidoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoCliente = await _context.PedidoCliente.FindAsync(id);
            if (pedidoCliente != null)
            {
                _context.PedidoCliente.Remove(pedidoCliente);
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
