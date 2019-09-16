using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<bool> ValidateUserCredintials(string userName, string password);
        Task<Models.Users> GetUserByUserName(string userName);
    }
}
