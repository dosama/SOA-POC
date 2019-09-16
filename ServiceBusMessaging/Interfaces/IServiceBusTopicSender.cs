using System.Threading.Tasks;
using ServiceBusMessaging.Models;

namespace ServiceBusMessaging.Interfaces
{
    public interface IServiceBusTopicSender
    {
        Task SendMessage(Payload payload);
    }
}
