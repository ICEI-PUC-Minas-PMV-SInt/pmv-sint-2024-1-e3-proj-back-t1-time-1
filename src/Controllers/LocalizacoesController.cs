using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharma.Models;
using System.Security.Claims;

namespace Pharma.Controllers
{
    public class LocalizacoesController: Controller
    {
        private readonly AppDbContext _context;
        public LocalizacoesController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Localizacao> dados;

            if (User.IsInRole("Admin"))
            {
              dados = await _context.Localizacoes.Include(l => l.Usuario).ToListAsync();
            } else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dados = await _context.Localizacoes.Include(l => l.Usuario).Where(l => l.UsuarioId == int.Parse(userId)).ToListAsync();
            }

           
            return View(dados);
        }

 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Localizacao localizacao)
        {

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                localizacao.UsuarioId = int.Parse(userId);
                _context.Localizacoes.Add(localizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(localizacao);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id  == null)
            {
                return NotFound();
            }

            var dados = await _context.Localizacoes.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

       [HttpPost]
       public async Task<IActionResult> Edit(int id, Localizacao localizacao)
        {
            if(id != localizacao.IdLocalizacao)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                
                _context.Localizacoes.Update(localizacao);
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
            var dados = await _context.Localizacoes.Include(loc => loc.Usuario).FirstAsync(loc => loc.IdLocalizacao == id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Localizacoes.Include(c => c.Usuario)
        .FirstAsync(c => c.IdLocalizacao == id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Localizacoes.Include(c => c.Usuario)
        .FirstAsync(c => c.IdLocalizacao == id);
            if (dados == null)
            {
                return NotFound();
            }

            _context.Localizacoes.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}
