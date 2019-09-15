using System.Threading.Tasks;

namespace ExamsService.Messaging.Interfaces
{
    public interface IServiceBusTopicSubscriber//<T> where T: TopicSubscriberBase
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
