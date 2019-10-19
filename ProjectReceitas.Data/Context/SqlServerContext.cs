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

            modelBuilder.Seed();
        }

       
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Login = "Nicholas", Nome = "Nicholas", Senha = "123" },
                new Usuario { Id = 2, Login = "Andre", Nome = "Andre", Senha = "123" },
                new Usuario { Id = 3, Login = "Wallace", Nome = "Wallace", Senha = "123" },
                new Usuario { Id = 4, Login = "Moraes", Nome = "Moraes", Senha = "123" }
            );
        }
    }
}
