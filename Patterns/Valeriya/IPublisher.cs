
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    interface IPublisher
    {
        void AddSubscriber(ISubscriber obj, Valeriya.Shop.MyHandler action);
        void RemoveSubscriber(ISubscriber obj, Valeriya.Shop.MyHandler action);
        void NotifySubscribers();
    }
}
