using Data.DBContext;
using Data.Repositories.Users;

namespace Data.Repositories.UserCourses
{
    public class UserCoursesRepository : Repository<Models.UserCourses>, IUserCoursesRepository
    {
        public UserCoursesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
