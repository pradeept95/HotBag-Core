using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.RabbitMQ.Publisher
{
    public class HotBagPublisherBase : IDisposable
    {
        protected IConnectionFactory _factory { get; set; }
        protected IConnection _connection { get; set; }
        protected IModel _channel { get; set; }

        public HotBagPublisherBase()
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

        }


        public void Dispose()
        { 
            if (_connection != null) _connection.Close();
            if (_channel != null) _channel.Close();
        }
    }
}
