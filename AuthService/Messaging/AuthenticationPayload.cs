using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBusMessaging.Models;

namespace AuthService.Messaging
{
    public class AuthenticationPayload:Payload
    {
        public string SessionId { get; set; }
    }
}
