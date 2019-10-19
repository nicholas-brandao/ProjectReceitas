using Microsoft.EntityFrameworkCore;
using ProjectReceitas.Data.Mapping;
using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<ReceitaIngrediente> ReceitaIngrediente { get; set; }
        public DbSet<ReceitaModoPreparo> ReceitaModoPreparo { get; set; }

        public SqlServerContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
