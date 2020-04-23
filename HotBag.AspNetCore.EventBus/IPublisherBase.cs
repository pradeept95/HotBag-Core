namespace HotBag.AspNetCore.EventBus
{
    public interface IPublisherBase
    {
    }

    public class PublisherBase
    {
        public EventBus bus;
        public PublisherBase()
        {
            bus = EventBus.Instance;
        } 
    }
}
