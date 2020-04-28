using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.RabbitMQ.Publisher;
using RabbitMQ.Client;
using System.Text;

namespace HotBag.Web.Host.MicroservicePublisher
{
    public class EmailPublisher : HotBagPublisherBase, IEmailPublisher, ITransientDependencies
    {
        public EmailPublisher() : base() // call base class constroctor
        {

        }
        public void PublishMessage(string message)
        {
            //_channel.ExchangeDeclare(
            //          exchange: "HotBag.Service.EmailService",
            //          type: "direct", // "topic", "direct", "headers", "fanout"
            //          durable: true,
            //          autoDelete: false,
            //          null
            //          );

            //_channel.QueueDeclare(queue: "EmailService.Default",
            //    durable: false,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: null);

            //_channel.QueueDeclare(queue: "EmailService.Extended",
            //   durable: false,
            //   exclusive: false,
            //   autoDelete: false,
            //   arguments: null);

            //_channel.QueueBind("EmailService.Default", "HotBag.Service.EmailService", "default", null);
            //_channel.QueueBind("EmailService.Extended", "HotBag.Service.EmailService", "extended", null);


            var defaultBody = Encoding.UTF8.GetBytes($"Default : {message}");
            var extendedBody = Encoding.UTF8.GetBytes($"Extended : {message}");

            _channel.BasicPublish(exchange: "HotBag.Service.EmailService",
                routingKey: "default",
                basicProperties: null,
                body: defaultBody);

            _channel.BasicPublish(exchange: "HotBag.Service.EmailService",
                routingKey: "extended",
                basicProperties: null,
                body: extendedBody);

        }
    }

    public interface IEmailPublisher
    {
        void PublishMessage(string message);
    }
}
