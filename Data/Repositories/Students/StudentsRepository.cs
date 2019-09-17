using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Students
{
    public class StudentsRepository : Repository<Models.Users>, IStudentsRepository
    {
        public StudentsRepository(SOAContext context) : base(context)
        {

        }

        public SOAContext SOAContext => Context as SOAContext;

        public async Task<List<Models.Users>> GetStudentsList()
        {
            return await SOAContext.Users.Include(u=>u.UserCourses).Include(u=>u.UserExams).ToListAsync();
        }

        public async  Task<Models.Users> GetStudentDetails(int studentId)
        {
            return await SOAContext.Users.FirstOrDefaultAsync(u => u.Id == studentId);
        }
    }
}
