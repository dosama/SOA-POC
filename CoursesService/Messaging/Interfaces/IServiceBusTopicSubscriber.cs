using System.Threading.Tasks;

namespace CoursesService.Messaging.Interfaces
{
    public interface IServiceBusTopicSubscriber//<T> where T: TopicSubscriberBase
    {
        void RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseSubscriptionClientAsync();
    }
}
