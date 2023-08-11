using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("ID");
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Senha).HasColumnName("SENHA").HasMaxLength(40).IsRequired();
            builder.Property(u => u.DtHrCriacao).HasColumnName("DTHRCRIACAO");
            builder.Property(u => u.DtHrAlteracao).HasColumnName("DTHRALTERACAO");

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Ignore(u => u.Token);

        }
    }
}
