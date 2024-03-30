﻿
using Microsoft.EntityFrameworkCore;
using Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Categoria>Categorias { get; set; } 
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
