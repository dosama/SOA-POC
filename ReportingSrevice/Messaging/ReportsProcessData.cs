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
            throw new NotImplementedException();
//            DataServiceSimi.Data.Add(new Payload
//            {
//                Name = myPayload.Name,
//                Goals = myPayload.Goals
//            });
        }
    }
}
