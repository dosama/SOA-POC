using System;
using AuthService.Messaging.Interfaces;

namespace AuthService.Messaging
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
