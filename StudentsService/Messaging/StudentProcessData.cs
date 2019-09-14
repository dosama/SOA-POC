using System;
using Messaging.Interfaces;
using Messaging.Models;

namespace StudentsService.Messaging
{
    internal class StudentProcessData:IProcessData
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
