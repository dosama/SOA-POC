using Data.DBContext;

namespace Data.Repositories.Courses
{
    class CoursesRepository : Repository<Models.Courses>, ICoursesRepository
    {
        public CoursesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
