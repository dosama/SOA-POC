using System;

namespace Data.Models
{
    public partial class StudentCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public Courses Course { get; set; }
        public Students Student { get; set; }
    }
}
