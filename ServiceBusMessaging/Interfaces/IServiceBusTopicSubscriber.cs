using System.Threading.Tasks;

namespace ServiceBusMessaging.Interfaces
{
    public interface IServiceBusTopicSubscriber
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
