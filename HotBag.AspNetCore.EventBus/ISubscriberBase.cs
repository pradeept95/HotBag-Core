namespace HotBag.AspNetCore.EventBus
{
    public interface ISubscriberBase
    {
    }

    public class SubscriberBase
    { 
        public EventBus eventBus;

        public SubscriberBase()
        {
            eventBus = EventBus.Instance;

        }
    }
}
