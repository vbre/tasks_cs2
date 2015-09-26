using System;
using System.Collections.Generic;
using System.Timers;

namespace Patterns.Valeriya
{
    class Shop: IPublisher
    {
        private static Timer timer = new Timer(5000);
        private Dictionary<ISubscriber, MyHandler> customersRegistry = new Dictionary<ISubscriber, MyHandler>();

        public delegate void MyHandler();
        public event MyHandler GoodArrived;

        public void AddSubscriber(ISubscriber subscriber, MyHandler action)
        {
            customersRegistry.Add(subscriber, action);
            GoodArrived += action;
        }

        public void RemoveSubscriber(ISubscriber subscriber, MyHandler action)
        {
            customersRegistry.Remove(subscriber);
            GoodArrived -= action;
        }

        public void NotifySubscribers()
        {
            if (GoodArrived != null)
            {
                GoodArrived();
            }
            else
            {
                Console.WriteLine("There are no subscribers");
            }
        }

        private void NotifyByTimer(Object source, ElapsedEventArgs e)
        {
            NotifySubscribers();
        }

        public Shop ()
        {
            timer.Start();
            timer.Elapsed += NotifyByTimer;
        }
    }
}
