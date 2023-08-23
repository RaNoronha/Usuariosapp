using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.AtualizarDados;
using Usuariosapp.Aplication.Models.Autenticar;
using Usuariosapp.Aplication.Models.CriarConta;
using Usuariosapp.Aplication.Models.RecuperarSenha;

namespace UsuariosApp.Aplication.Interfaces
{
    public interface IUsuarioAppService
    {
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);
        RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model);
        AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string email);
    }
}
