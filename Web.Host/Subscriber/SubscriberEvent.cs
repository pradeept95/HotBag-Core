using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus;
using System;
using System.Threading.Tasks;

namespace Web.Host.Subscriber
{
    public class SubscriberEvent : SubscriberBase, ITransientDependencies
    {
        Subscription<BaseData> fileLoggerToken;

        public override void InitializeSubscription()
        {
            fileLoggerToken = eventBus.Subscribe<BaseData>(this.LogInFile);
        }

        public override async Task InitializeSubscriptionAsync()
        {
            fileLoggerToken = await Task.FromResult(eventBus.Subscribe<BaseData>(this.LogInFile));
        }

        private void LogInFile(BaseData fileLoggerMessage)
        {
            Console.WriteLine($"===============================");
            Console.WriteLine($"Id : { fileLoggerMessage.Id } ===");
            Console.WriteLine($"Message :  {fileLoggerMessage.Message}");
            Console.WriteLine($"===============================");

            var logger = HotBag.AspNetCore.Log.LogInFile.Instance;

            logger.Log($"Test {DateTime.Now}");

            //eventBus.UnSbscribe(fileLoggerToken);
        }
    }
}
