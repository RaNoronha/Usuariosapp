using System.ComponentModel.DataAnnotations;

namespace Usuariosapp.Services.Models.Autenticar
{
    public class AutenticarRequestModel
    {
        [Required(ErrorMessage = "Por favor, preencha a Senha")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a senha")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?!.*\s).{8,}$", ErrorMessage = " Combine letras maiúsculas e minúsculas, números e caracteres especiais, com no mínimo 8 caracteres.")]
        public string? Senha { get; set; }
    }
}
