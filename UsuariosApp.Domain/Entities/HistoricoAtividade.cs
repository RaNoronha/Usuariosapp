using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Enums;

namespace UsuariosApp.Domain.Entities
{
    public class HistoricoAtividade
    {        
        public Guid? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public TipoAtividade? Tipo { get; set; }
        public string? Descricao { get; set; }

        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
