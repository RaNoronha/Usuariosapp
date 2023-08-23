using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarConta(Usuario usuario);
        Usuario Autenticar(string email, string senha);
        Usuario RecuperarSenha(string email);
        Usuario AtualizarDados(string email, string nome, string senha);

    }
}
