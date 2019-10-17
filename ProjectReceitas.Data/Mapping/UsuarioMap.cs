
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnName("Login");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");
        }
    }
}
