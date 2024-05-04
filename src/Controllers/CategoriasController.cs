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
        public CategoriasController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Categoria> dados;


            if (User.IsInRole("Admin"))
            {
                 dados = await _context.Categorias.Include(c => c.Usuario).ToListAsync();
     

            } else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dados = await _context.Categorias
                    .Include(c => c.Usuario)
                    .Where(c => c.UsuarioId == int.Parse(userId))
                    .ToListAsync();
          
            }
           
            return View(dados);
        }

        //Método Get
        public IActionResult Create() {

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
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int? id) {
     

            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Categorias.FindAsync(id);
        
            
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {

            if (id != categoria.Id_categoria)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
