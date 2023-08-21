using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Messages.Models;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Services
{
    public class UsuarioMessageProducer : IUsuarioMessage
    {
        public void SendMessage(string para, string assunto, string corpo)
        {
            var settings = new RabbitMQSettings();
            var model = new UsuarioMessageModel();            

            model.Id = Guid.NewGuid();
            model.Para = para;
            model.Assunto = assunto;
            model.Corpo = corpo;
            model.DtCriacao = DateTime.Now;

            var connectionFactory = new ConnectionFactory();

            connectionFactory.Uri = new Uri(settings.Caminho);

            using (var connection = connectionFactory.CreateConnection() )
            {
                using(var fila = connection.CreateModel())
                {
                    fila.QueueDeclare(
                        queue: settings.Fila,
                        durable: true,
                        autoDelete: false,
                        exclusive: false,
                        arguments: null
                    );

                    fila.BasicPublish(
                        exchange: string.Empty,
                        routingKey: settings.Fila,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
                        );
                }
            }
        }
    }
}
