using System;
using Messaging.Interfaces;
using Messaging.Models;

namespace CoursesService.Messaging
{
    internal class CoursesProcessData:IProcessData
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
