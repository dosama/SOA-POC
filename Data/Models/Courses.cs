using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Courses
    {
        public Courses()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
