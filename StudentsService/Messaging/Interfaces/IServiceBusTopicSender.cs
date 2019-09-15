using System.Threading.Tasks;

namespace StudentsService.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(object payload);
    }
}
