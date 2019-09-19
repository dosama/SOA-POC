using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Students
{
    public class StudentsRepository : Repository<Models.Students>, IStudentsRepository
    {
        public StudentsRepository(SOAContext context) : base(context)
        {

        }

        public SOAContext SOAContext => Context as SOAContext;

        public async Task<List<Models.Students>> GetStudentsList()
        {
            return await SOAContext.Students.Include(u=>u.StudentCourses).ThenInclude(c=> c.Course).Include(u=>u.StudentExams).ThenInclude(e=>e.Exam).ToListAsync();
        }

        public async  Task<Models.Students> GetStudentDetails(int studentId)
        {
            return await SOAContext.Students.FirstOrDefaultAsync(u => u.Id == studentId);
        }
    }
}
