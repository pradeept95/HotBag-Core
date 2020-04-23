using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus;
using System;

namespace Web.Host.Subscriber
{
    public class SubscriberEvent : SubscriberBase, ITransientDependencies
    {
        Subscription<BaseData> fileLoggerToken;

        public void InitializeSubscription()
        {
            fileLoggerToken = eventBus.Subscribe<BaseData>(this.LogInFile);
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
