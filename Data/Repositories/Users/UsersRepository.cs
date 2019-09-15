using System.Linq;
using System.Threading.Tasks;
using Data.DBContext;

namespace Data.Repositories.Users
{
    public class UsersRepository : Repository<Models.Users>, IUsersRepository
    {
        public UsersRepository(SOAContext context) : base(context)
        {

        }

        public SOAContext SOAContext => Context as SOAContext;
        public async Task<bool> ValidateUserCredintials(string userName, string password)
        {
            var user =  await GetUserByUserName(userName);

            return user == null || user.Password == password;
        }

        public async Task<Models.Users> GetUserByUserName(string userName)
        {
            return SOAContext.Users.FirstOrDefault(u => u.UserName == userName);

        }
    }
}
