namespace AuthService.ViewModels
{
    public class LoginResponseModelVm
    {
        public bool SessionId { get; set; }
        public bool IsAuthenticated { get; set; }
        public UserDetailsVm UserDetails { get; set; }
    }
}
