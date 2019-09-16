using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;


namespace ExamsService.Messaging
{
    internal class ExamsProcessData:IProcessData
    {
        public Task Process(Payload payload)
        {
            return null;
        }
    }
}
