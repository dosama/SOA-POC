using System;
using StudentsService.Messaging.Interfaces;

namespace StudentsService.Messaging
{
    internal class StudentProcessData:IProcessData
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
