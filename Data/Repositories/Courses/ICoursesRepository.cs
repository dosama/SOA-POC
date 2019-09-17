using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Courses
{
    public interface ICoursesRepository
    {
        Task<List<Models.Courses>> GetCoursesList();
        Task<Models.Courses> GetCourseDetails(int courseId);
    }
}
