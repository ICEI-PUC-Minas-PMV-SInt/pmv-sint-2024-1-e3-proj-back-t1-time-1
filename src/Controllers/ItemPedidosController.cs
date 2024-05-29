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
    public class ItemPedidosController : Controller
    {
        private readonly AppDbContext _context;

        public ItemPedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ItemPedidos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ItemPedido.Include(i => i.PedidosCliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ItemPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido
                .Include(i => i.PedidosCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // GET: ItemPedidos/Create
        public IActionResult Create()
        {
            ViewData["PedidoClienteId"] = new SelectList(_context.PedidoCliente, "Id", "NotaFiscal");
            return View();
        }

        // POST: ItemPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,ValorUnitario,ValorTotal,PedidoClienteId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoClienteId"] = new SelectList(_context.PedidoCliente, "Id", "NotaFiscal", itemPedido.PedidoClienteId);
            return View(itemPedido);
        }

        // GET: ItemPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoClienteId"] = new SelectList(_context.PedidoCliente, "Id", "NotaFiscal", itemPedido.PedidoClienteId);
            return View(itemPedido);
        }

        // POST: ItemPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,ValorUnitario,ValorTotal,PedidoClienteId")] ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPedidoExists(itemPedido.Id))
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
            ViewData["PedidoClienteId"] = new SelectList(_context.PedidoCliente, "Id", "NotaFiscal", itemPedido.PedidoClienteId);
            return View(itemPedido);
        }

        // GET: ItemPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido
                .Include(i => i.PedidosCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // POST: ItemPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido != null)
            {
                _context.ItemPedido.Remove(itemPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItemPedido.Any(e => e.Id == id);
        }
    }
}
