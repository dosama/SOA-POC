using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace AuthService.Messaging
{
    internal class AuthProcessData:IProcessData
    {
        private readonly IServiceBusTopicSender _serviceBusTopicSender;
        public AuthProcessData(IServiceBusTopicSender serviceBusTopicSender)
        {
            _serviceBusTopicSender = serviceBusTopicSender;
        }
        public Task Process(Payload payload)
        {
            if (payload.ActionName == "Test")
            {
                _serviceBusTopicSender.SendMessage(new Payload() {ActionName = "MessageRecieved"});
            }

            return null;
        }
    }
}
