using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.RabbitMQ.WorkerServiceBase;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.EmailService.Service
{
    public class EmailWorkerService : HotBagWorkerService, IEmailWorkerService, ITransientDependencies
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
            var consumerDefault = new EventingBasicConsumer(_channel);
            consumerDefault.Received += ReceiveDefaultMessage;
            _channel.BasicConsume("EmailService.Default", autoAck: false, consumer: consumerDefault);

            var consumerExtended = new EventingBasicConsumer(_channel);
            consumerExtended.Received += ReceiveExtendedMessage;
            _channel.BasicConsume("EmailService.Extended", autoAck: false, consumer: consumerExtended);


            await base.ExecuteAsync(stoppingToken);
        }

        public void ReceiveDefaultMessage(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received: {message}");

            //if any error is happend
            // set as Nak : done by BasicNack
            //_channel.BasicNack(ea.DeliveryTag, false, true);

            //after successfully manupulating data
            // set as ack : done by BasicAck
            _channel.BasicAck(ea.DeliveryTag, false);
        }

        public void ReceiveExtendedMessage(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received: {message}");

            //if any error is happend
            // set as Nak : done by BasicNack
            //_channel.BasicNack(ea.DeliveryTag, false, true);

            //after successfully manupulating data
            // set as ack : done by BasicAck
            _channel.BasicAck(ea.DeliveryTag, false);
        }
    }
    
}
