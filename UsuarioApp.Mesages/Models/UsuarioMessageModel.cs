using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Models
{
    public class UsuarioMessageModel
    {
        public Guid Id { get; set; }
        public string? Para { get; set; }
        public string? Assunto { get; set;}
        public string? Corpo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
