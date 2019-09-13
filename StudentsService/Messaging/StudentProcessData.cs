using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Messaging.Interfaces;
using Infrastructure.Messaging.Models;

namespace StudentsAPI.Messaging
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
