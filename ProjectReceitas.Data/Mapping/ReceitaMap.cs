
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Data.Mapping
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(c => c.HoraPreparo)
                .IsRequired()
                .HasColumnName("HoraPreparo");

            builder.Property(c => c.MinutoPreparo)
                .IsRequired()
                .HasColumnName("MinutoPreparo");

            builder.Property(c => c.Rendimento)
                .IsRequired()
                .HasColumnName("Rendimento");
        }
    }
}
