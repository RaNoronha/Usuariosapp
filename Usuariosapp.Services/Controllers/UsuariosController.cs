using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuariosapp.Aplication.Models.AtualizarDados;
using Usuariosapp.Aplication.Models.Autenticar;
using Usuariosapp.Aplication.Models.CriarConta;
using Usuariosapp.Aplication.Models.RecuperarSenha;
using UsuariosApp.Aplication.Interfaces;

namespace Usuariosapp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region Injeção de Dependência

        private readonly IUsuarioAppService? _usuarioAppService;

        public UsuariosController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        #endregion

        #region POST

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponseModel), 201)]
        public IActionResult CriarConta([FromBody] CriarContaRequestModel model)
        {
            try
            {
                var response = _usuarioAppService?.CriarConta(model);
                return StatusCode(201, response);

            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 201)]
        public IActionResult Autenticar([FromBody] AutenticarRequestModel model)
        {
            try
            {
                var response = _usuarioAppService?.Autenticar(model);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("recuperar-senha")]
        [HttpPost]
        [ProducesResponseType(typeof(RecuperarSenhaResponseModel), 201)]
        public IActionResult RecuperarSenha([FromBody] RecuperarSenhaRequestModel model)
        {
            try
            {
                var response = _usuarioAppService.RecuperarSenha(model);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        #endregion

        #region PUT

        [Authorize]
        [Route("atualizar-dados")]
        [HttpPut]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 201)]
        public IActionResult AtualizarDados([FromBody] AtualizarDadosRequestModel model)
        {
            try
            {
                var email = User.Identity.Name;

                var response = _usuarioAppService.AtualizarDados(model, email);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        #endregion

    }
}
