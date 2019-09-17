using System.Collections.Generic;

namespace ReportingBusiness.Models
{
   public class ReportModel
    {
        public List<ExamModel> Exams { get; set; }
        public List<StudentDetails> Students { get; set; }
        public List<CourseModel> Courses { get; set; }
    }
}
