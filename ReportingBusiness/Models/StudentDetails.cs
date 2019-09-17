using System;
using System.Collections.Generic;

namespace ReportingBusiness.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<ExamModel> Exams { get; set; }

    }
}
