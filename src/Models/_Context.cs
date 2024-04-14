using Microsoft.EntityFrameworkCore;

namespace Pharma.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // Coloquem as tabelas aqui para adicioná-las ao contexto
        // O nome da variável para as tabelas sempre serão no plural!
        // Enquanto a classe do modelo em si é sempre no singular
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}