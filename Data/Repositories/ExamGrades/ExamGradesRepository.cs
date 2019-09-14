using Data.DBContext;
using Data.Repositories.Users;

namespace Data.Repositories.ExamGrades
{
    public class ExamGradesRepository : Repository<Models.ExamGrades>, IExamGradesRepository
    {
        public ExamGradesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
