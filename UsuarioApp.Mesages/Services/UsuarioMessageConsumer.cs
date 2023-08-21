using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Helpers;
using UsuariosApp.Messages.Models;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Services
{
    public class UsuarioMessageConsumer : BackgroundService
    {
        private readonly IServiceProvider? _serviceProvider;        
        private IConnection? _connection;
        private IModel? _model;
        private RabbitMQSettings? _rabbitMQSettings;

        public UsuarioMessageConsumer(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory();
            connectionFactory.Uri = new Uri(_rabbitMQSettings.Caminho);

            _connection = connectionFactory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                        queue: _rabbitMQSettings.Fila,
                        durable: true,
                        autoDelete: false,
                        exclusive: false,
                        arguments: null
                    );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += async (sender, args) =>
            {
                var payload = Encoding.UTF8.GetString(args.Body.ToArray());

                var usuarioMessageModel = JsonConvert.DeserializeObject<UsuarioMessageModel>(payload);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailMessageHelper = new EmailMessageHelper();
                    emailMessageHelper.EnvioEmail(usuarioMessageModel);

                    _model.BasicAck(args.DeliveryTag, false);
                }
            };

            _model.BasicConsume(_rabbitMQSettings.Fila, false, consumer);
        }
    }
}
