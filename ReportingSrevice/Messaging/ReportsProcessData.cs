using System;
using System.Threading.Tasks;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace ReportingService.Messaging
{
    internal class ReportsProcessData : IProcessData
    {
        public Task Process(Payload payload)
        {
            return null;
        }
    }
}
