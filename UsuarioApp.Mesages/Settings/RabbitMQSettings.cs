using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    public class RabbitMQSettings
    {
        public string Caminho { get => "amqps://ywalymxo:RtiU8ml0Bminxz-ODAHRleZLmk5pb2le@jackal.rmq.cloudamqp.com/ywalymxo"; }

        public string Fila { get => "mensagens_usuarios"; }
    }
}
