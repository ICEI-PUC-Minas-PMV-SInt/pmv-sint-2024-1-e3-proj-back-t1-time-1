using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharma.Models;

namespace Pharma.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: AccessDenied
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            string invalidCredentials = "Nome de usuário ou senha inválidos";

            var data = await _context.Usuario.FirstOrDefaultAsync(u =>
                                    u.AcessoUsuario == usuario.AcessoUsuario
                                );
            if (data == null)
            {
                ViewBag.Message = invalidCredentials;

                return View();
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, data.Senha);
            if (isPasswordValid)
            {
                List<Claim> claims = [
                    new(ClaimTypes.NameIdentifier, data.Id.ToString()),
                    new(ClaimTypes.Name, data.AcessoUsuario),
                    new(ClaimTypes.Role, data.Cargo.ToString()),
                ];

                ClaimsIdentity userIdentification = new(claims, "login");
                ClaimsPrincipal principal = new(userIdentification);

                AuthenticationProperties props = new()
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);
                return Redirect("/");
            }
            else
            {
                ViewBag.Message = invalidCredentials;
            }

            return View();
        }

        // POST: Logout
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AcessoUsuario,Senha,Cargo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Se você for o primeiro a registrar, será automaticamente um admin
                    // Usuários subsequentemente registrados serão automaticamente farmacêuticos.
                    // Após isso, apenas admins poderão adicionar outros admins.
                    bool isFirstUser = !_context.Usuario.Any();
                    usuario.Cargo = isFirstUser ? Cargos.Admin : Cargos.Farmaceutico;

                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return User.Identity.IsAuthenticated
                           ? RedirectToAction(nameof(Index))
                           : RedirectToAction("Login", "Usuarios");
                }
                catch (DbUpdateException err)
                {
                    if (err.InnerException is DbException dbException && dbException.Message.Contains("UNIQUE constraint failed"))
                    {
                        ModelState.AddModelError("AcessoUsuario", "Este nome para acesso já existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Um erro aconteceu ao salvar. Tente novamente");
                    }
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AcessoUsuario,Senha,Cargo")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        private async Task<bool> IsLastAdminAsync(int usuarioId)
        {
            int adminAmount = await _context
                                    .Usuario
                                    .Where(u => u.Cargo == Cargos.Admin && u.Id != usuarioId)
                                    .CountAsync();

            return adminAmount == 0;
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            if (
                usuario != null &&
                usuario.Cargo == Cargos.Admin &&
                await IsLastAdminAsync((int)id)
               )
            {
                TempData["Message"] = "Não é possível deletar o último administrador";

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
