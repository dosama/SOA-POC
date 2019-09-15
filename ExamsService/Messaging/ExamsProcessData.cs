using System;
using ExamsService.Messaging.Interfaces;


namespace ExamsService.Messaging
{
    internal class ExamsProcessData:IProcessData
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
