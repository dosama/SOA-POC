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
            throw new NotImplementedException();
//            DataServiceSimi.Data.Add(new Payload
//            {
//                Name = myPayload.Name,
//                Goals = myPayload.Goals
//            });
        }
    }
}
