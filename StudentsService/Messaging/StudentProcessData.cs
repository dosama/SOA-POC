using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messaging.Interfaces;
using Messaging.Models;

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
