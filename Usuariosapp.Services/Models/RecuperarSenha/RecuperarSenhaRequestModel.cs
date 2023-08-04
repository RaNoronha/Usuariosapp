using System.ComponentModel.DataAnnotations;

namespace Usuariosapp.Services.Models.RecuperarSenha
{
    public class RecuperarSenhaRequestModel
    {
        [Required(ErrorMessage = "Por favor, preencha a Senha")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido")]
        public string? Email { get; set; }
    }
}
