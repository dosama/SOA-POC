using Data.DBContext;

namespace Data.Repositories.Users
{
    public class UsersRepository : Repository<Models.Users>, IUsersRepository
    {
        public UsersRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
