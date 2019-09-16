using System.Threading.Tasks;
using ServiceBusMessaging.Models;

namespace ServiceBusMessaging.Interfaces
{
    public interface IProcessData
    {
        Task Process(Payload myPayload);
    }
}
