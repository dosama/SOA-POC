using System.Collections.Generic;

namespace CoursesBusiness.Models
{
   public class CourseDetailsModel
    {
        public CourseDetailsModel()
        {
            CourseStudents = new List<StudentDetails>();
        }
        public CourseModel CourseDetails { get; set; }
        public List<StudentDetails> CourseStudents { get; set; }
    }
}
