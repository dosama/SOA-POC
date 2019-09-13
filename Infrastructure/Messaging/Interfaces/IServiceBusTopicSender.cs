using System.Threading.Tasks;
using Infrastructure.Messaging.Models;

namespace Infrastructure.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(PayloadBase payload);
    }
}
