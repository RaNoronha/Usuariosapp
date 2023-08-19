using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        #region Injeção de Dependência

        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IHistoricoAtividadeRepository? _historicoAtividadeRepository;
        private readonly ITokenSecuity? _tokenSecurity;
        private readonly IUsuarioMessage? _usuarioMessage;

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, IHistoricoAtividadeRepository? historicoAtividadeRepository, ITokenSecuity? tokenSecurity, IUsuarioMessage? usuarioMessage)
        {
            _usuarioRepository = usuarioRepository;
            _historicoAtividadeRepository = historicoAtividadeRepository;
            _tokenSecurity = tokenSecurity;
            _usuarioMessage = usuarioMessage;
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
            var usuario = _usuarioRepository?.Get(email, MD5Helper.Encrypt(senha));

            if(usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado");
            }

            var historicoAtividade = new HistoricoAtividade();

            historicoAtividade.Id = Guid.NewGuid();
            historicoAtividade.Tipo = Enums.TipoAtividade.AUTENTICAÇÃO;
            historicoAtividade.DataHora = DateTime.Now;
            historicoAtividade.Descricao = $"Autenticação do usuário {usuario.Nome} realizado com sucesso";
            historicoAtividade.UsuarioId = usuario.Id;

            _historicoAtividadeRepository.Cadastrar(historicoAtividade);

            usuario.Token = _tokenSecurity?.GerarToken(usuario);

            return usuario;
        }

        public Usuario RecuperarSenha(string email)
        {
            var usuario = _usuarioRepository.Get(email);

            if(usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            var novaSenha = PasswordHelper.GeneratePassword();

            usuario.Senha = MD5Helper.Encrypt(novaSenha);
            _usuarioRepository.Atualizar(usuario);

            var para = usuario.Email;
            var assunto = "Recuperação de senha de usuário";
            var corpo = $@"
                <div style='padding: 40px; margin: 40px; border: 1px solid #ccc; text-align: center;'>
                    <img src='https://www.cotiinformatica.com.br/imagens/logo-coti-informatica.png'/>
                    <hr/>
                    <h5>Olá {usuario.Nome}</h5>
                    <p>Uma nova senha de acesso foi gerada para você.</p>
                    <p>Acesse o sistema com a senha: {novaSenha}</p>
                    <br/>
                    <p>Att, equipe COTI Informática</p>
                </div>
            ";

            _usuarioMessage.SendMessage(para, assunto, corpo);

            var historicoAtividade = new HistoricoAtividade();

            historicoAtividade.Id = Guid.NewGuid();
            historicoAtividade.Tipo = Enums.TipoAtividade.RECUPERAÇÃO_DE_SENHA;
            historicoAtividade.DataHora = DateTime.Now;
            historicoAtividade.Descricao = $"Senha do usuário {usuario.Nome} recuperada com sucesso";
            historicoAtividade.UsuarioId = usuario.Id;

            _historicoAtividadeRepository.Cadastrar(historicoAtividade);

            return usuario;
        }

        public bool AtualizarDados(Guid? id, string nome, string senha)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
