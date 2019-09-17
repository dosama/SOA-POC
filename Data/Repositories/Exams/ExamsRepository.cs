using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Exams
{
    public class ExamsRepository : Repository<Models.Exams>, IExamsRepository
    {
        public ExamsRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
        public async Task<List<Models.Exams>> GetExamsList()
        {
            return await SOAContext.Exams.ToListAsync();
        }

        public async Task<Models.Exams> GetExamDetails(int examId)
        {
            return await SOAContext.Exams.Include(u => u.UserExams).FirstOrDefaultAsync(u => u.Id == examId);
        }
    }
}
