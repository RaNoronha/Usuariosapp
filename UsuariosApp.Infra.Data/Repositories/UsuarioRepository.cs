using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Get(string email)
        {
            using (var context = new DataContext())
            {
                return context.Usuario.FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario Get(string email, string senha)
        {
            using (var context = new DataContext())
            {
                return context.Usuario.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
            }
        }
    }
}
