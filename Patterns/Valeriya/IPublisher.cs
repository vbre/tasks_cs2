
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    interface IPublisher
    {
        void AddSubscriber(ISubscriber obj);
        void RemoveSubscriber(ISubscriber obj);
        void NotifySubscribers();
    }
}
