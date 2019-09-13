using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Exams
    {
        public Exams()
        {
            UserExams = new HashSet<UserExams>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Duration { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<UserExams> UserExams { get; set; }
    }
}
