using System;

namespace HotBag.AspNetCore.EventBus
{
    public interface IEventBus
    {
        void Publish<TMessageType>(TMessageType message);
        Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action);
        void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription);
    }
}