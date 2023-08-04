using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Usuariosapp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region POST

        [Route("criar-conta")]
        [HttpPost]
        public IActionResult CriarConta()
        {
            return Ok();
        }

        [Route("autenticar")]
        [HttpPost]
        public IActionResult Autenticar()
        {
            return Ok();
        }

        [Route("recuperar-senha")]
        [HttpPost]
        public IActionResult RecuperarSenha()
        {
            return Ok();
        }

        #endregion

        #region PUT

        [Route("atualizar-dados")]
        [HttpPut]
        public IActionResult AtualizarDados()
        {
            return Ok();
        }

        #endregion

    }
}
