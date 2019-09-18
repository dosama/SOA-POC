using System.Collections.Generic;

namespace WebApplication2.ViewModels
{
   public class CourseDetailsModelVm
    {
        public CourseModelVm CourseDetails { get; set; }
        public List<StudentDetailsVm> CourseStudents { get; set; }
    }
}
