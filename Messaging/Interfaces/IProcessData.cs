using System;
using System.Collections.Generic;
using System.Text;
using Messaging.Models;

namespace Messaging.Interfaces
{
    public interface IProcessData
    {
         void Process(PayloadBase payload);
    }
}
