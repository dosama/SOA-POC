using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace StudentsService.Messaging
{
    internal class StudentProcessData:IProcessData
    {
        public Task Process(Payload payload)
        {
            return null;
        }
    }
}
