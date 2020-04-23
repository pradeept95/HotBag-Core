using System;
using System.Reflection;

namespace HotBag.AspNetCore.EventBus
{
    //Does used by EventBus to reserve subscription
    public class Subscription<Tmessage> : IDisposable
    {
        public readonly MethodInfo MethodInfo;
        private readonly HotBagEventBus EventAggregator;
        public readonly WeakReference TargetObjet;
        public readonly bool IsStatic;

        private bool isDisposed;
        public Subscription(Action<Tmessage> action, HotBagEventBus eventAggregator)
        {
            MethodInfo = action.Method;
            if (action.Target == null)
                IsStatic = true;
            TargetObjet = new WeakReference(action.Target);
            EventAggregator = eventAggregator;
        }

        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }

        public void Dispose()
        {
            EventAggregator.UnSbscribe(this);
            isDisposed = true;
        }

        public Action<Tmessage> CreatAction()
        {
            if (TargetObjet.Target != null && TargetObjet.IsAlive)
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), TargetObjet.Target, MethodInfo);
            if (this.IsStatic)
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), MethodInfo);

            return null;
        }
    }

}
