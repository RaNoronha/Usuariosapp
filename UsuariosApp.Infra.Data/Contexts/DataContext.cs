using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Infra.Data.Mappings;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //conexão MyAsp
            optionsBuilder.UseSqlServer("Data Source=SQL5111.site4now.net;Initial Catalog=db_a9e29e_usuariosappbd;User Id=db_a9e29e_usuariosappbd_admin;Password=Lz5365@pq");

            //conexão casa
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDUsuariosApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new HistoricoAtividadeMap());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<HistoricoAtividade> HistoricoAtividade { get; set; }
    }
}
