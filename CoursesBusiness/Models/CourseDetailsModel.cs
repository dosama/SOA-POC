using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesBusiness.Models
{
   public class CourseDetailsModel
    {
        public CourseModel CourseDetails { get; set; }
        public List<StudentDetails> CourseStudents { get; set; }
    }
}
