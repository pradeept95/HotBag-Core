using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotBag.AspNetCore.EventBus
{
    /*
    *  Sealed restricts the inheritance
    */
    public sealed class HotBagEventBus : IEventBus
    {

        //Lazy initialization
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static readonly Lazy<HotBagEventBus> instance
            = new Lazy<HotBagEventBus>(() => new HotBagEventBus());


        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static HotBagEventBus Instance
        {
            get
            {
                //Eager initialization for thread safety
                //if (instance == null)
                //    instance = new EventBus();
                return instance.Value;
            }
        }


        private readonly object lockObj = new object();
        private Dictionary<Type, IList> subscriber;


        /*
         * Private constructor ensures that object is not
         * instantiated other than with in the class itself
         */
        private HotBagEventBus()
        {
            subscriber = new Dictionary<Type, IList>();
        }

        public void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList sublst;
            if (subscriber.ContainsKey(t))
            {
                lock (lockObj)
                {
                    sublst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
                }

                foreach (Subscription<TMessageType> sub in sublst)
                {
                    var action = sub.CreatAction();
                    if (action != null)
                        action(message);
                }
            }
        }

        public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new Subscription<TMessageType>(action, this);

            lock (lockObj)
            {
                if (!subscriber.TryGetValue(t, out actionlst))
                {
                    actionlst = new List<Subscription<TMessageType>>();
                    actionlst.Add(actiondetail);
                    subscriber.Add(t, actionlst);
                }
                else
                {
                    actionlst.Add(actiondetail);
                }
            }

            return actiondetail;
        }

        public void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscriber.ContainsKey(t))
            {
                lock (lockObj)
                {
                    subscriber[t].Remove(subscription);
                }
                subscription = null;
            }
        }

    }

}
