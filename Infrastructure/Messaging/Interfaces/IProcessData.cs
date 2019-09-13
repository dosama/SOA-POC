using Infrastructure.Messaging.Models;

namespace Infrastructure.Messaging.Interfaces
{
    public interface IProcessData
    {
         void Process(PayloadBase payload);
    }
}
