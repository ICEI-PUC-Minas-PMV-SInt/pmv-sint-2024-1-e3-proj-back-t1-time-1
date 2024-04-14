
﻿using Microsoft.EntityFrameworkCore;
using Pharma.Models;
using System.Collections.Generic;

namespace Pharma.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // Coloquem as tabelas aqui para adicioná-las ao contexto
        // O nome da variável para as tabelas sempre serão no plural!
        // Enquanto a classe do modelo em si é sempre no singular
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pharma.Models.PedidoCliente> PedidoCliente { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}