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

        // GET: ItemPedidoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ItensPedido.Include(i => i.PedidoCliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ItemPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido
                .Include(i => i.PedidoCliente)
                .FirstOrDefaultAsync(m => m.IdItemProduto == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // GET: ItemPedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.PedidoCliente, "IdPedido", "NtFiscal");
            return View();
        }

        // POST: ItemPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItemProduto,QtProduto,VlUnitario,VlTotalItem,IdPedido")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.PedidoCliente, "IdPedido", "NtFiscal", itemPedido.IdPedido);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.PedidoCliente, "IdPedido", "NtFiscal", itemPedido.IdPedido);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItemProduto,QtProduto,VlUnitario,VlTotalItem,IdPedido")] ItemPedido itemPedido)
        {
            if (id != itemPedido.IdItemProduto)
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
                    if (!ItemPedidoExists(itemPedido.IdItemProduto))
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
            ViewData["IdPedido"] = new SelectList(_context.PedidoCliente, "IdPedido", "NtFiscal", itemPedido.IdPedido);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido
                .Include(i => i.PedidoCliente)
                .FirstOrDefaultAsync(m => m.IdItemProduto == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // POST: ItemPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido != null)
            {
                _context.ItensPedido.Remove(itemPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.IdItemProduto == id);
        }
    }
}
