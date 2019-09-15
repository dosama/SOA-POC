using System;
using ReportingService.Messaging.Interfaces;

namespace ReportingService.Messaging
{
    internal class ReportProcessData : IProcessData
    {
        public void Process(object payload)
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
