using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        #region Atributos

        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IHistoricoAtividadeRepository? _historicoAtividadeRepository;

        #endregion

        #region Método Construtor

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, IHistoricoAtividadeRepository? historicoAtividadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _historicoAtividadeRepository = historicoAtividadeRepository;
        }

        #endregion

        #region Impementação da Interface

        public void CriarConta(Usuario usuario)
        {
            if (_usuarioRepository?.Get(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            _usuarioRepository?.Cadastrar(usuario);

            var historicoAtividade = new HistoricoAtividade();

            historicoAtividade.Id = Guid.NewGuid();
            historicoAtividade.Tipo = Enums.TipoAtividade.CRIAÇÃO_DE_USUÁRIO;
            historicoAtividade.DataHora = DateTime.Now;
            historicoAtividade.Descricao = $"Cadastro do usuário {usuario.Nome} realizado com sucesso";
            historicoAtividade.UsuarioId = usuario.Id;

            _historicoAtividadeRepository.Cadastrar(historicoAtividade);

        }

        public Usuario Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario RecuperarSenha(string email)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarDados(Guid? id, string nome, string senha)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
