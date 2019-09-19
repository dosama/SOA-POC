using System.Collections.Generic;

namespace ExamsBusiness.Models
{
   public class ExamDetailsModel
    {
        public ExamDetailsModel()
        {
            ExamStudents = new List<StudentDetails>();
        }
        public ExamModel ExamDetails { get; set; }
        public List<StudentDetails> ExamStudents { get; set; }
    }
}
