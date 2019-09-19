using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Students
{
    public interface IStudentsRepository
    {
        Task<List<Models.Students>> GetStudentsList();
        Task<Models.Students> GetStudentDetails(int studentId);
    }
}
