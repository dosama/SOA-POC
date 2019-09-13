using System;
using System.Collections.Generic;

namespace Data
{
    public partial class UserCourses
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public Courses Course { get; set; }
        public CourseStatus Status { get; set; }
        public Users User { get; set; }
    }
}
