using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Exams
{
    public interface IExamsRepository
    {
        Task<List<Models.Exams>> GetExamsList();
        Task<Models.Exams> GetExamDetails(int examId);
    }
}
