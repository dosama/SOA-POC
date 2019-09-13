using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CourseStatus
    {
        public CourseStatus()
        {
            UserCourses = new HashSet<UserCourses>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<UserCourses> UserCourses { get; set; }
    }
}
