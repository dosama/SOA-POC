using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace CoursesService.Messaging
{
    internal class CoursesProcessData :IProcessData
    {
        public Task Process(Payload payload)
        {
            return null;
        }
    }
}
