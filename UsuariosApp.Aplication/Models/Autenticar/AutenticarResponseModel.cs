namespace Usuariosapp.Aplication.Models.Autenticar
{
    public class AutenticarResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public DateTime? HoraAcesso { get; set; }
        public DateTime? HoraExpiracao { get; set; }
    }
}
