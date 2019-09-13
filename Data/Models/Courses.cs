using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Courses
    {
        public Courses()
        {
            UserCourses = new HashSet<UserCourses>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<UserCourses> UserCourses { get; set; }
    }
}
