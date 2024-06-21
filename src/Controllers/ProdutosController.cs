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
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        string emptyLocations = "Registre uma localização antes de registrar uma venda.";

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            /*
                Evitar que produtos possam ser registrados sem uma localização
                já existente no banco de dados.
            */
            bool hasLocations = _context.Localizacao.Any();
            ViewBag.HasLocations = hasLocations;
            ViewBag.EmptyLocations = emptyLocations;

            var appDbContext = _context.Produto.Include(p => p.Categoria).Include(p => p.Localizacao).Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .Include(p => p.Localizacao)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome");
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacao, "Id", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "AcessoUsuario");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,CategoriaId,LocalizacaoId,NomeProduto,Descricao,DataCadastro")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacao, "Id", "Nome", produto.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "AcessoUsuario", produto.UsuarioId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacao, "Id", "Nome", produto.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "AcessoUsuario", produto.UsuarioId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,CategoriaId,LocalizacaoId,NomeProduto,Descricao,DataCadastro")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["LocalizacaoId"] = new SelectList(_context.Localizacao, "Id", "Nome", produto.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "AcessoUsuario", produto.UsuarioId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .Include(p => p.Localizacao)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
