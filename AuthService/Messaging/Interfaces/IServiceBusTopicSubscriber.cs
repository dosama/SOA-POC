using System.Threading.Tasks;

namespace AuthService.Messaging.Interfaces
{
    public interface IServiceBusTopicSubscriber//<T> where T: TopicSubscriberBase
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
