using Data.DBContext;

namespace Data.Repositories.UserExams
{
    public class UserExamsRepository : Repository<Models.UserExams>, IUserExamsRepository
    {
        public UserExamsRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
