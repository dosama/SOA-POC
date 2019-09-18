using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace WebApplication2.Messaging
{
    internal  class WebApplication2ProcessData :IProcessData
    {
        public Task Process(Payload payload)
        {
            if (payload.ActionName == "MessageRecieved")
            {
               
            }

            return null;
        }
    }
}
