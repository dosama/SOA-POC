using System.Collections.Generic;
using System.Threading.Tasks;
using ExamsBusiness.Models;

namespace ExamsBusiness.Service
{
    public interface IExamsService
    {
         Task<List<ExamModel>> GetExamsList();
         Task<ExamDetailsModel> GetExamDetails(int examId);
    }
}
