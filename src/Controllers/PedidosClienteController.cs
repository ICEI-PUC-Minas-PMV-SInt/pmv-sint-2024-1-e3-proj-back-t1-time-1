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
    public class PedidosClienteController : Controller
    {
        private readonly AppDbContext _context;

        public PedidosClienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PedidosCliente
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoCliente.Include(p => p.Clientes);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PedidosCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // GET: PedidosCliente/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf");
            return View();
        }

        // POST: PedidosCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPedido,NotaFiscal,TotalPedido,ClienteId")] PedidoCliente pedidoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", pedidoCliente.ClienteId);
            return View(pedidoCliente);
        }

        // GET: PedidosCliente/Edit/5
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", pedidoCliente.ClienteId);
            return View(pedidoCliente);
        }

        // POST: PedidosCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPedido,NotaFiscal,TotalPedido,ClienteId")] PedidoCliente pedidoCliente)
        {
            if (id != pedidoCliente.Id)
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
                    if (!PedidoClienteExists(pedidoCliente.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", pedidoCliente.ClienteId);
            return View(pedidoCliente);
        }

        // GET: PedidosCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoCliente = await _context.PedidoCliente
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoCliente == null)
            {
                return NotFound();
            }

            return View(pedidoCliente);
        }

        // POST: PedidosCliente/Delete/5
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
            return _context.PedidoCliente.Any(e => e.Id == id);
        }
    }
}
