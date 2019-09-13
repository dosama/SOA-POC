using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Users
    {
        public Users()
        {
            UserCourses = new HashSet<UserCourses>();
            UserExams = new HashSet<UserExams>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public UserRoles Role { get; set; }
        public ICollection<UserCourses> UserCourses { get; set; }
        public ICollection<UserExams> UserExams { get; set; }
    }
}
