using System.ComponentModel.DataAnnotations;

namespace Usuariosapp.Services.Models.AtualizarDados
{
    public class AtualizarDadosRequestModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no míimo 5 caracteres ")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo 80 caracteres")]
        public string? Nome { get; set; }

        
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?!.*\s).{8,}$", ErrorMessage = " Combine letras maiúsculas e minúsculas, números e caracteres especiais, com no mínimo 8 caracteres.")]
        public string? Senha { get; set; }

        
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string? SenhaConfirmacao { get; set; }
    }
}
