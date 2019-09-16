using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsBusiness.Models;

namespace StudentsBusiness.Service
{
    public interface IStudentsService
    {
         Task<List<StudentDetails>> GetStudentsList();
         Task<StudentDetails> GetStudentDetails(int studentId);
    }
}
