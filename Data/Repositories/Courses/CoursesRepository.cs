using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Courses
{
    class CoursesRepository : Repository<Models.Courses>, ICoursesRepository
    {
        public CoursesRepository(SOAContext context) : base(context)
        {
        }

        public SOAContext SOAContext => Context as SOAContext;
        public async Task<List<Models.Courses>> GetCoursesList()
        {
            return await SOAContext.Courses.Include(u => u.StudentCourses).ThenInclude(s => s.Student).ToListAsync();
        }

        public async Task<Models.Courses> GetCourseDetails(int courseId)
        {
            return await SOAContext.Courses.Include(u=>u.StudentCourses).ThenInclude(s=>s.Student).FirstOrDefaultAsync(u => u.Id == courseId);
        }
    }
}
