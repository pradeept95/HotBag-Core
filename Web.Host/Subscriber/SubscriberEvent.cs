using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Host.Subscriber
{
    public class SubscriberEvent : SubscriberBase, ITransientDependencies, ISubscriberEvent
    {
        Subscription<BaseData> fileLoggerToken;
        Subscription<BaseData> databaseLoggerToken;
 
        public override async Task InitializeSubscriptionAsync()
        {
            fileLoggerToken = await Task.FromResult(eventBus.Subscribe<BaseData>(this.LogInFile));
            databaseLoggerToken = await Task.FromResult(eventBus.Subscribe<BaseData>(this.LogInDatabase));
        } 

        private void LogInFile(BaseData fileLoggerMessage)
        { 
            var logger = HotBag.AspNetCore.Log.LogInFile.Instance;
            //Thread.Sleep(10000);
            logger.Log($"Test {DateTime.Now}");

            //eventBus.UnSbscribe(fileLoggerToken);
        }

        private void LogInDatabase(BaseData fileLoggerMessage)
        { 
            var logger = HotBag.AspNetCore.Log.LogInFile.Instance;
            //Thread.Sleep(10000);
            logger.Log($"Test {DateTime.Now}");

            //eventBus.UnSbscribe(fileLoggerToken);
        }
    }

    public class SubscriberEvent1 : SubscriberBase, ITransientDependencies
    {
        public override async Task InitializeSubscriptionAsync()
        {
            await base.InitializeSubscriptionAsync();
        }

        public override void InitializeSubscription()
        {
            base.InitializeSubscription();
        }
    }
}
