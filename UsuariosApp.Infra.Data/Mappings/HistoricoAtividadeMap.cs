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
    public class HistoricoAtividadeMap : IEntityTypeConfiguration<HistoricoAtividade>
    {
        public void Configure(EntityTypeBuilder<HistoricoAtividade> builder)
        {
            builder.ToTable("HISTORICOATIVIDADE");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("ID");
            builder.Property(u => u.DataHora).HasColumnName("DATAHORA");
            builder.Property(u => u.Tipo).HasColumnName("TIPO").IsRequired();
            builder.Property(u => u.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();
            builder.Property(u => u.UsuarioId).HasColumnName("USUARIO_ID").IsRequired();

            builder.HasOne(u => u.Usuario).WithMany(u => u.Historicos).HasForeignKey(u => u.UsuarioId);
        }
    }
}
