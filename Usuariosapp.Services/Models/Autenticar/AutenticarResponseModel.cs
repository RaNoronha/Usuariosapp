using Microsoft.AspNetCore.Identity;

namespace Usuariosapp.Services.Models.Autenticar
{
    public class AutenticarResponseModel
    {
        public Guid? ID { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public DateTime? HoraAcesso { get; set; }
        public DateTime? HoraExpiracao { get; set; }
    }
}
