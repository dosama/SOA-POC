using System;
using Messaging.Interfaces;
using Messaging.Models;

namespace ReportingService.Messaging
{
    internal class ReportProcessData : IProcessData
    {
        public void Process(PayloadBase payload)
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
