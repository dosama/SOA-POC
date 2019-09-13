using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messaging.Models;

namespace Messaging.Interfaces
{
    public interface IServiceBusTopicSubscriber//<T> where T: TopicSubscriberBase
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
