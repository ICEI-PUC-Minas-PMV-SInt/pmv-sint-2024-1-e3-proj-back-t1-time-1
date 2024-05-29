using Microsoft.EntityFrameworkCore;

namespace Pharma.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacaoEstoque { get; set; }
        public DbSet<PedidoCliente> PedidoCliente { get; set; }
        public DbSet<PedidoCompra> PedidoCompra { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Especificações para a criação de campos únicos e afins
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasIndex(u => u.AcessoUsuario).IsUnique();
        }
    }
}