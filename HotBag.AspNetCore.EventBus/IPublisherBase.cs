using System.Threading.Tasks;

namespace HotBag.AspNetCore.EventBus
{
    public interface IPublisherBase
    {
      
    }

    public abstract class PublisherBase : IPublisherBase
    {
        public HotBagEventBus eventBus;
        public PublisherBase()
        {
            eventBus = HotBagEventBus.Instance;
        } 
    }
}
