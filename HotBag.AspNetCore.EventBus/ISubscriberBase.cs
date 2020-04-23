using System.Threading.Tasks;

namespace HotBag.AspNetCore.EventBus
{
    public interface ISubscriberBase
    {
        Task InitializeSubscriptionAsync();
        void InitializeSubscription();
    }

    public abstract class SubscriberBase : ISubscriberBase
    { 
        public HotBagEventBus eventBus;

        public SubscriberBase()
        {
            eventBus = HotBagEventBus.Instance;

        }

        public virtual void InitializeSubscription()
        {
            
        }

        public virtual async Task InitializeSubscriptionAsync()
        {
            await Task.FromResult(true);
        }
    }
}
