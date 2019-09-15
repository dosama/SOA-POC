using System.Threading.Tasks;

namespace ReportingService.Messaging.Interfaces
{
    public interface IServiceBusTopicSubscriber//<T> where T: TopicSubscriberBase
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
