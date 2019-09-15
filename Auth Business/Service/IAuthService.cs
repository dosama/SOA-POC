using System.Threading.Tasks;
using Auth_Business.Models;

namespace Auth_Business.Service
{
    public interface IAuthService
    {
         Task<LoginResponse> Login(LoginRequest request);
    }
}
