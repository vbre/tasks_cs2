using System;
using System.Collections.Generic;
using System.Timers;

namespace Patterns.Valeriya
{
    class Shop: IPublisher
    {
        private static Timer timer = new Timer(5000);
        private List<ISubscriber> customerList = new List<ISubscriber>();

        public delegate void MyHandler();
        public event MyHandler ShopClosed;
        public event MyHandler GoodArrived;

        public void AddSubscriber(ISubscriber obj)
        {
            customerList.Add(obj);
        }

        public void RemoveSubscriber(ISubscriber obj)
        {
            customerList.Remove(obj);
        }

        public void NotifySubscribers()
        {
            if (GoodArrived != null)
                GoodArrived();

            if (ShopClosed != null)
                ShopClosed();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            NotifySubscribers();
        }

        public Shop ()
        {
            timer.Start();
            timer.Elapsed += OnTimedEvent;
        }
    }
}
