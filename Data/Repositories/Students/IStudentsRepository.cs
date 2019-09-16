using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Students
{
    public interface IStudentsRepository
    {
        Task<List<Models.Users>> GetStudentsList();
        Task<Models.Users> GetStudentDetails(int studentId);
    }
}
