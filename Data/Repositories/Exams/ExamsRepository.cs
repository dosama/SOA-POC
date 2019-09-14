using Data.DBContext;

namespace Data.Repositories.Exams
{
    public class ExamsRepository : Repository<Models.Exams>, IExamsRepository
    {
        public ExamsRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
    }
}
