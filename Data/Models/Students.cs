using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentCourses = new HashSet<StudentCourses>();
            StudentExams = new HashSet<StudentExams>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
        public ICollection<StudentExams> StudentExams { get; set; }
    }
}
