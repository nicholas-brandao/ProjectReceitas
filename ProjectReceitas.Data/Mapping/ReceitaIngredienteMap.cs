
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Data.Mapping
{
    public class ReceitaIngredienteMap : IEntityTypeConfiguration<ReceitaIngrediente>
    {
        public void Configure(EntityTypeBuilder<ReceitaIngrediente> builder)
        {
            builder.ToTable("ReceitaIngrediente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("Descricao");

            builder.Property(c => c.Receita)
                .IsRequired();

            builder.HasOne(c => c.Receita).WithMany(e => e.Ingredientes);
        }
    }
}
