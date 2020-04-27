using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.RabbitMQ.Type
{
    public static class ExchangeType
    {
        public static string Direct() => "direct";
        public static string Topic() => "topic";
        public static string Headers() => "headers";
        public static string Fanout() => "fanout";
        
    }
}
