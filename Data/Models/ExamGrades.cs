using System;
using System.Collections.Generic;

namespace Data
{
    public partial class ExamGrades
    {
        public ExamGrades()
        {
            UserExams = new HashSet<UserExams>();
        }

        public int Id { get; set; }
        public string Grade { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<UserExams> UserExams { get; set; }
    }
}
