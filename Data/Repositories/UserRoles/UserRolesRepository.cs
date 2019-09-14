using Data.DBContext;

namespace Data.Repositories.UserRoles
{
    public class UserRolesRepository : Repository<Models.UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
