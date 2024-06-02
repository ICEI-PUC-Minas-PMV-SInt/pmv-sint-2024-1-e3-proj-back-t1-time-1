using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharma.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Pharma.Controllers
{
    public class CategoriasController : Controller
    {
        //Contexto do banco de dados 
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Categoria> dados;


            if (User.IsInRole("Admin"))
            {
                dados = await _context.Categoria.Include(c => c.Usuarios).ToListAsync();


            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dados = await _context.Categoria
                    .Include(c => c.Usuarios)
                    .Where(c => c.UsuarioId == int.Parse(userId))
                    .ToListAsync();

            }

            return View(dados);
        }

        //Método Get
        public IActionResult Create()
        {

            return View();
        }

        //Método Post
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {



            if (ModelState.IsValid)
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Defina o UsuarioId da categoria com o ID do usuário logado
                categoria.UsuarioId = int.Parse(userId);
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Categoria.FindAsync(id);


            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {

            if (id != categoria.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _context.Categoria.Update(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Categoria.Include(c => c.Usuarios)
        .FirstAsync(c => c.Id == id);
            if (dados == null)
            {
                return NotFound();
            }
            ViewBag.AcessoUsuario = dados.Usuarios.AcessoUsuario;
            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Categoria.Include(c => c.Usuarios)
        .FirstAsync(c => c.Id == id);
            if (dados == null)
            {   
                return NotFound();
            }
            ViewBag.AcessoUsuario = dados.Usuarios.AcessoUsuario;
            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Categoria.Include(c => c.Usuarios)
        .FirstAsync(c => c.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}