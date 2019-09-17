using System.Collections.Generic;
using System.Threading.Tasks;
using CoursesBusiness.Models;

namespace CoursesBusiness.Service
{
    public interface ICoursesService
    {
         Task<List<CourseModel>> GetCoursesList();
         Task<CourseDetailsModel> GetCourseDetails(int courseId);
    }
}
