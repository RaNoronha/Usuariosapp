namespace Usuariosapp.Aplication.Models.CriarConta
{
    public class CriarContaResponseModel
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public DateTime? DataHoraCriacao { get; set; }
    }
}
