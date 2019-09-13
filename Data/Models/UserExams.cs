using System;

namespace Data.Models
{
    public partial class UserExams
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int? GradeId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public Exams Exam { get; set; }
        public ExamGrades Grade { get; set; }
        public Users User { get; set; }
    }
}
