using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EventBus;

namespace Web.Host.Publisher
{
    public class PublishEvent :  PublisherBase, IPublishEvent, ITransientDependencies
    {
        public void Publish()
        {
            eventBus.Publish<BaseData>(new BaseData { Id = 1, Message = "Message" });
        }
    }

    public interface IPublishEvent
    {
        void Publish();
    }
}
