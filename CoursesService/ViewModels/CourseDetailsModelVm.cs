using System.Collections.Generic;
using CoursesBusiness.Models;

namespace CoursesService.ViewModels
{
   public class CourseDetailsModelVm
    {
        public CourseModelVm CourseDetails { get; set; }
        public List<StudentDetailsVm> CourseStudents { get; set; }
    }
}
