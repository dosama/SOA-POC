using Data.DBContext;

namespace Data.Repositories.CourseStatus
{
    public class CourseStatusRepository : Repository<Models.CourseStatus>, ICourseStatusRepository
    {
        public CourseStatusRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
