using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace WebApp.Messaging
{
    internal  class WebAppProcessData :IProcessData
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
