using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Cadastrar(T entity);
        void Atualizar(T entity);
        void Apagar(T entity);
        List<T> PesquisarTodos();
        T PesquisaId(Guid id);
    }
}
