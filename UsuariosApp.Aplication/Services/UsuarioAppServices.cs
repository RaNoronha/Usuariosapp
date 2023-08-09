using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuariosapp.Aplication.Models.AtualizarDados;
using Usuariosapp.Aplication.Models.Autenticar;
using Usuariosapp.Aplication.Models.CriarConta;
using Usuariosapp.Aplication.Models.RecuperarSenha;
using UsuariosApp.Aplication.Interfaces;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Aplication.Services
{
    public class UsuarioAppServices : IUsuarioAppService
    {
        #region Injeção de Dependência

        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuarioAppServices(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        #endregion

        #region Implementação da Interface

        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {
            var usuario = new Usuario();

            usuario.Id = Guid.NewGuid();
            usuario.Nome = model.Nome;
            usuario.Email = model.Email;
            usuario.Senha = model.Senha;
            usuario.DtHrCriacao = DateTime.Now.ToString("dd/MM/yyyy");
            usuario.DtHrAlteracao = DateTime.Now.ToString("dd/MM/yyyy");

            _usuarioDomainService?.CriarConta(usuario);

            var response = new CriarContaResponseModel();

            response.Id = usuario.Id;
            response.Nome = usuario.Nome;
            response.Email = usuario.Email;
            response.DataHoraCriacao = DateTime.Parse(usuario.DtHrCriacao);

            return response;
        }

        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            throw new NotImplementedException();
        }

        public RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model)
        {
            throw new NotImplementedException();
        }

        public AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
