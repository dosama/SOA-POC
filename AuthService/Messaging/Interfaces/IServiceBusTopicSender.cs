using System.Threading.Tasks;

namespace AuthService.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(object payload);
    }
}
