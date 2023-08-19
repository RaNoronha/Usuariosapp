using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Messages
{
    public interface IUsuarioMessage
    {
        void SendMessage(string para, string assunto, string corpo);
    }
}
