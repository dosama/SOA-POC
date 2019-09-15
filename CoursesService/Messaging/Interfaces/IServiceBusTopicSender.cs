using System.Threading.Tasks;

namespace CoursesService.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(object payload);
    }
}
