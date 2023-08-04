using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuariosapp.Services.Models.AtualizarDados;
using Usuariosapp.Services.Models.Autenticar;
using Usuariosapp.Services.Models.CriarConta;
using Usuariosapp.Services.Models.RecuperarSenha;

namespace Usuariosapp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region POST

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponseModel), 201)]
        public IActionResult CriarConta([FromBody] CriarContaRequestModel model)
        {
            return Ok();
        }

        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 201)]
        public IActionResult Autenticar([FromBody] AutenticarRequestModel model)
        {
            return Ok();
        }

        [Route("recuperar-senha")]
        [HttpPost]
        [ProducesResponseType(typeof(RecuperarSenhaResponseModel), 201)]
        public IActionResult RecuperarSenha([FromBody] RecuperarSenhaRequestModel model)
        {
            return Ok();
        }

        #endregion

        #region PUT

        [Route("atualizar-dados")]
        [HttpPut]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 201)]
        public IActionResult AtualizarDados([FromBody] AtualizarDadosRequestModel model)
        {
            return Ok();
        }

        #endregion

    }
}
