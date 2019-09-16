using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace AuthService.Messaging
{
    internal class AuthProcessData:IProcessData
    {
        public Task Process(Payload payload)
        {
            throw new NotImplementedException();

        }
    }
}
