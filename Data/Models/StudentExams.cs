using System;

namespace Data.Models
{
    public partial class StudentExams
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public Exams Exam { get; set; }
        public Students Student { get; set; }
    }
}
