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

            Debug.WriteLine(User.IsInRole("Admin"), "testeee");

            if (User.IsInRole("Admin"))
            {
                 dados = await _context.Categorias.ToListAsync();

            } else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dados = await _context.Categorias
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

                Debug.WriteLine(userId, categoria, "testeeeeeeeee");
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
    }
}
