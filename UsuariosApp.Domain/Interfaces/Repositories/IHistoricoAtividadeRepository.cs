using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IHistoricoAtividadeRepository : IBaseRepository<HistoricoAtividade>
    {
        List<HistoricoAtividade> Get(Guid usuarioId);
    }
}
