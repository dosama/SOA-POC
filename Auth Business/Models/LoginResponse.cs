using System;
using System.Collections.Generic;
using System.Text;

namespace Auth_Business.Models
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
