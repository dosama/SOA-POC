using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messaging.Models;

namespace Messaging.Interfaces
{
    public interface IServiceBusTopicSender//<T> where T : TopicBase
    {
        Task SendMessage(PayloadBase payload);
    }
}
