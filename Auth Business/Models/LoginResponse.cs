namespace Auth_Business.Models
{
    public class LoginResponse
    {
        public bool SessionId { get; set; }
        public bool IsAuthenticated { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
