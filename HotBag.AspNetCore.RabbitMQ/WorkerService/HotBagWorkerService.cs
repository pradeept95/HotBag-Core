using HotBag.AspNetCore.DI;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.RabbitMQ.WorkerServiceBase
{
    public class HotBagWorkerService : BackgroundService, IHotBagWorkerService
    {
        protected IConnectionFactory _factory { get; set; }
        protected IConnection _connection { get; set; }
        protected IModel _channel { get; set; }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (_connection != null) _connection.Close();
            if (_channel != null) _channel.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.FromResult(true); 
        }
    }
}
