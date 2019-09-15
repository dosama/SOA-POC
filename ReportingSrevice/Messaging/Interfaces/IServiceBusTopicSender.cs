using System.Threading.Tasks;

namespace ReportingService.Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(object payload);
    }
}
