using System.Threading.Tasks;

namespace ExamsService.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(object payload);
    }
}
