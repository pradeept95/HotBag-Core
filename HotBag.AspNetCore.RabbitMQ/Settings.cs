using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.RabbitMQ
{
    public class RabbitMQSettings
    {
        public string HostName { get; set; } = "localhost";
        public string VirtualHost { get; set; } = "/";
        public int Port { get; set; } = 5672;
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
    }
}
