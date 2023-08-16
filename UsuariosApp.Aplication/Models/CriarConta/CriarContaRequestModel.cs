using System.ComponentModel.DataAnnotations;

namespace Usuariosapp.Aplication.Models.CriarConta
{
    public class CriarContaRequestModel
    {
        [Required(ErrorMessage = "Por favor, preencha o nome")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo 5 caracteres ")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo 80 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a Senha")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a senha")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?!.*\s).{8,}$", ErrorMessage = " Combine letras maiúsculas e minúsculas, números e caracteres especiais, com no mínimo 8 caracteres.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Por favor. preencha a confirmação da senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string? SenhaConfirmacao { get; set; }
    }
}
