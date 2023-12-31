﻿using System;
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
            usuario.DtHrCriacao = DateTime.Now;
            usuario.DtHrAlteracao = DateTime.Now;

            _usuarioDomainService?.CriarConta(usuario);

            var response = new CriarContaResponseModel();

            response.Id = usuario.Id;
            response.Nome = usuario.Nome;
            response.Email = usuario.Email;
            response.DataHoraCriacao = usuario.DtHrCriacao;

            return response;
        }

        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

            var response = new AutenticarResponseModel();

            response.Id = usuario.Id;
            response.Nome = usuario.Nome;
            response.Email = usuario.Email;
            response.Token = usuario.Token;
            response.HoraAcesso = DateTime.UtcNow;
            response.HoraExpiracao = DateTime.UtcNow.AddMinutes(60);

            return response;
        }

        public RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(model.Email);

            var response = new RecuperarSenhaResponseModel();

            response.Id = usuario.Id;
            response.Nome = usuario.Nome;
            response.Email = usuario.Email;
            response.HoraRecuperacaoSenha = DateTime.Now;

            return response;
        }

        public AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string email)
        {
            var usuario = _usuarioDomainService.AtualizarDados(email, model.Nome, model.Senha);

            var response = new AtualizarDadosResponseModel();

            response.Id = usuario.Id;
            response.Nome = usuario.Nome;
            response.Email = usuario.Email;
            response.HoraAlteracao = DateTime.Now;

            return response;
        }

        #endregion

    }
}
